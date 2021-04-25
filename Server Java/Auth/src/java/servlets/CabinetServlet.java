package servlets;

import java.io.File;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.StandardCopyOption;
import javax.servlet.ServletException;
import javax.servlet.annotation.MultipartConfig;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.Part;
import utilits.Hasher;

/**
 *
 * @author artem
 */
@WebServlet("/cabmin")
@MultipartConfig
public class CabinetServlet extends HttpServlet {

    @Override
    protected void doGet(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {

        //req.setAttribute("fromservlet", "Hello2");
        req.getRequestDispatcher("cabinet.jsp").forward(req, resp);
    }

    @Override
    protected void doPost(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {

        req.setAttribute("post", "prishlo");
        String username = req.getParameter("username");
        String userpass = req.getParameter("userpass");
        String userpass2 = req.getParameter("userpass2");
        String useremail = req.getParameter("useremail");
        Part avatar = req.getPart("useravatar");
        String fileName = avatar.getSubmittedFileName();

        String res = "UPDATE Users SET ";
        boolean needComma = false;

        if (userpass != null && !userpass.equals("")) {
            // Изменение пароля
            // Проверяем совпадение паролей
            if (!userpass.equals(userpass2)) {

                req.setAttribute("error", "несовпадения паролей");
                //  HW 12.04   Доработать реакцию на ошибку несовпадения паролей
                req.getRequestDispatcher("cabinet.jsp").forward(req, resp);
                return;
            } else {
                // Расчет хеш 
                String salt = ((orm.User) req.getAttribute("authUser")).getSalt();
                String passHash = Hasher.md5(userpass + salt);

                // и обновление пароля
                res += "pass_hash='" + passHash + "' ";
                needComma = true;
            }
        }

        if (username != null && !username.equals("")) {
            if (needComma) {
                res += ",";
            } else {
                needComma = true;
            }
            res += "name='" + username + "' ";
        }

        if (useremail != null && !useremail.equals("")) {
            if (needComma) {
                res += ",";
            } else {
                needComma = true;
            }
            res += "email='" + useremail + "' ";
        }
        File delete = null;
        if (fileName != null && !fileName.equals("")) {
            // Загрузка нового файла
            // Получаем путь к расположению проекта с сервлетом
            String path = getServletContext().getRealPath("./../../web/avatars");
            // Создаем файл для сохранения переданных данных

            int dotPotition = fileName.lastIndexOf(".");
            String baseName = fileName.substring(0, dotPotition);
            String savedExt = fileName.substring(dotPotition + 1);

            String savedName = baseName;

            File updated = new File(path, savedName + "." + savedExt);
            // Копируем из потока filePart в новый файл

            // Загружаемые файлы могуть называться одинаково
            // Проверяем на наличие файла и меняем имя, если существует
            int i = 1;
            while (updated.isFile()) {
                //4) если есть добавляем 1 к имени
                savedName = baseName + i;
                updated = new File(path, savedName + "." + savedExt);
                i++;
            }
            // копируем в папку
            Files.copy(
                    avatar.getInputStream(),
                    updated.toPath(),
                    StandardCopyOption.REPLACE_EXISTING
            );
            // удаляем временный файл
            avatar.delete();

            // итоговое имя файла - savedName + "." + savedExt
            fileName = savedName + "." + savedExt;

            // имя файла
            String oldAvatar = ((orm.User) req.getAttribute("authUser")).getAvatar();
            // в path - путь сохранения
            delete = new File(path, oldAvatar);

            if (needComma) {
                res += ",";
            } else {
                needComma = true;
            }
            res += "avatar='" + fileName + "' ";
        }

        res += " WHERE id=" + ((orm.User) req.getAttribute("authUser")).getId();

        if (utilits.UserUtil.update(res)) {
            //Обеспечить удаление старого файла-аватарки после загрузки нового
            if (delete != null) {
                // Удаляем старый файл
                // удаляем, используя анонимный файловый объект
                if (delete.delete()) {
                    System.out.println("File deleted successfully");
                } else {
                    System.out.println("Failed to delete the file");
                }
            }
        }

        req.setAttribute("restart", "need");
        req.getRequestDispatcher("cabinet.jsp").forward(req, resp);
        //Реализовать возврат в кабинет после обработки данных
        // Проверить факт обновления данных, работоспособность нового пароля

    }

}
