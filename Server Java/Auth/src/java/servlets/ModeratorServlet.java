package servlets;

import java.io.File;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.StandardCopyOption;
import java.util.ArrayList;
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
@WebServlet("/moder/*")
@MultipartConfig
public class ModeratorServlet extends HttpServlet {

    @Override
    protected void doGet(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        //resp.getWriter().print("Ok");  // проверка

        ArrayList<orm.NewsComment> comments = (ArrayList<orm.NewsComment>) utilits.NewsUtils.getCommentsList();
        ArrayList<orm.News> news = (ArrayList<orm.News>) utilits.NewsUtils.getList();
        String[] uriParts = req.getRequestURI().split("/");

        if (uriParts.length <= 3) {
            req.getRequestDispatcher("/moder.jsp").forward(req, resp);

        } else {
            if (uriParts[3].equals("news")) {
                req.setAttribute("newsList", news);
                req.getRequestDispatcher("/moder_news.jsp").forward(req, resp);
            } else {
                req.setAttribute("commentsList", comments);
                req.getRequestDispatcher("/moder_comments.jsp").forward(req, resp);
            }
        }
    }

    @Override
    protected void doPost(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {

        String command = req.getParameter("command");
        String cid = req.getParameter("cid");
        String reason = req.getParameter("reason");
        if (command == null) {
            resp.getWriter().print("Error");
            return;
        }
        switch (command) {
            case "toggleComment":
                if (cid == null) {
                    resp.getWriter().print("Error 3");
                    return;
                }
                if (utilits.NewsUtils.disableComment(cid)) {
                    resp.getWriter().print("success");
                } else {
                    resp.getWriter().print("Error 4");
                }
                break;
            case "toggleNews":
                if (cid == null) {
                    resp.getWriter().print("Error 5");
                    return;
                }
                if (utilits.NewsUtils.disableNews(cid, reason)) {
                    resp.getWriter().print("success");
                } else {
                    resp.getWriter().print("Error 6");
                }
                break;
            case "addNews":
                Part avatar = req.getPart("avatar");

                String avatarName = avatar.getSubmittedFileName();
                String title = req.getParameter("title");
                String content_short = req.getParameter("short");
                String content_full = req.getParameter("full");

                //resp.getWriter().print(avatarName + " " + title + " " + content_short + " " + content_full);
                /* работа с фоткой 
                    1) достаем имя
                    2) если есть делим имя на части
                    3) проверка есть ли такой фаил в папки
                    4) если есть добавляем 1 к имени
                    5) добавка в папку
                 */
                String savedName = null;
                String savedExt = null;

                // 2) если есть делим имя на части
                if (avatarName != null) {

                    String path = getServletContext().getRealPath("./../../web/newsavatars");
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
                    
                    avatarName = savedName + "." + savedExt;
                    avatarName.replace("'", "\\'");
                    avatarName = "'" + savedName + "." + savedExt + "'";
                    // 5) добавка в папку
                    Files.copy(
                            avatar.getInputStream(),
                            updated.toPath(),
                            StandardCopyOption.REPLACE_EXISTING
                    );
                    // удаляем временный файл
                    avatar.delete();
                }

                orm.User user = (orm.User) req.getAttribute("authUser");
                if (utilits.NewsUtils.addNews(title, content_short, content_full, avatarName, user.getId())) {
                    resp.getWriter().print("success");
                } else {
                    resp.getWriter().print("Error 8");
                }
                break;
            default:
                resp.getWriter().print("Error 2");
                return;
        }

        //resp.getWriter().print("Ok " + command + " " + cid );
    }

}
