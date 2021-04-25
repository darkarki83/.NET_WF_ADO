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

/**
 *
 * @author artem
 */
@WebServlet("/reg")
@MultipartConfig
public class RegServlet extends HttpServlet {

    @Override
    protected void doGet(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        req.getRequestDispatcher("reg.jsp").forward(req, resp);
    }

    @Override
    protected void doPost(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {

        /* проверка есть ли такой ник      */
        String massage = null;
        String username = req.getParameter("username");

        if (util.RegUtil.haveUser(username) != 0) {
            massage = "Есть такое имя";

            req.setAttribute("regMassage", massage);
            req.getRequestDispatcher("reg.jsp").forward(req, resp);
            return;
        }

        /* с перенапровлением сюдаже */
            /* работа с фоткой 
            1) достаем имя
            2) если есть делим имя на части
            3) проверка есть ли такой фаил в папки
            4) если есть добавляем 1 к имени
            5) добавка в папку
         */
        Part avatar = req.getPart("useravatar");

        //1) достаем имя
        String avatarName = avatar.getSubmittedFileName();

        String savedName = null;
        String savedExt = null;

        // 2) если есть делим имя на части
        if (!"".equals(avatarName)) {

            String path = getServletContext().getRealPath("./../../web/avatars");
            // Создаем файл для сохранения переданных данных

            int dotPotition = avatarName.lastIndexOf(".");
            String baseName = avatarName.substring(0, dotPotition);
            savedExt = avatarName.substring(dotPotition + 1);

            savedName = baseName;

            File updated = new File(path, savedName + "." + savedExt);
            // Копируем из потока filePart в новый файл

            //3) проверка есть ли такой фаил в папки
            int i = 1;
            while (updated.isFile()) {
                //4) если есть добавляем 1 к имени
                savedName = baseName + i;
                updated = new File(path, savedName + "." + savedExt);
                i++;
            }

            // 5) добавка в папку
            Files.copy(
                    avatar.getInputStream(),
                    updated.toPath(),
                    StandardCopyOption.REPLACE_EXISTING
            );
            // удаляем временный файл
            avatar.delete();
        }
        /* параметры из формы    */
        String avatarFull = null;
        if (savedName != null) {
            avatarFull = "'" + savedName + "." + savedExt + "'";
        }

        String userpass = req.getParameter("userpass");
        String useremail = req.getParameter("useremail");
        /* создание соли и хэша   */
        String salt = util.Hasher.md5(username);
        String hash = util.Hasher.md5(userpass + salt);

        /* добавляем в базу       */
        if (util.RegUtil.addUser(username, hash, salt, useremail, avatarFull)) {
            massage = String.format("Регистрация %s прошла успешна", username);
        }

        req.setAttribute("regMassage", massage);
        req.getRequestDispatcher("reg.jsp").forward(req, resp);
    }
}
