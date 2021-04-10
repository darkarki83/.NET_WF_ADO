package servlets;

import java.io.IOException;
import java.sql.Date;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.text.SimpleDateFormat;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;
import utilits.Db;
import utilits.Hasher;

/**
 *
 * @author artem
 */
@WebServlet("/auth")
public class AuthServlet extends HttpServlet {

    @Override
    protected void doGet(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        req.getRequestDispatcher("authorization.jsp").forward(req, resp);
    }

    @Override
    protected void doPost(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        // Принимаем параметры
        String login = req.getParameter("login");
        String pass = req.getParameter("pass");

        // сообщение для отображения
        String massage = null;

        // Д.З. Составить код для проверки авторизации
        try {
            ResultSet res = Db.getConnection()
                    .createStatement()
                    .executeQuery("SELECT * FROM Users WHERE nik LIKE '"
                            + login + "' ");

            if (res.next()) {
                // Есть запись с таким nik
                String passHash = res.getString("pass_hash");
                String passSalt = res.getString("pass_salt");

                if (passHash.equals(Hasher.md5(pass + passSalt))) {
                    // Авторизация подтверждена
                    massage = "Hi " + login;
                    // Механизм сессий позволяет сохранить данные об авторизации
                    HttpSession session = req.getSession();
                    session.setAttribute("authUserId", res.getInt("id"));
                    session.setAttribute("name", res.getString("name"));

                    /*   update last_visit                     */
                    SimpleDateFormat formatter = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
                    Date date = new Date(System.currentTimeMillis());
                    System.out.println(formatter.format(date));

                    try {
                        Db.getConnection()
                                .createStatement()
                                .executeUpdate(
                                        String.format(
                                                "UPDATE Users SET moment_last_visit = '%s' WHERE id=%d",
                                                formatter.format(date),
                                                res.getInt("id")
                                        ));
                    } catch (InstantiationException | SQLException ex) {
                        System.out.println(ex.getMessage());
                    }
                    /*  finsh block             */
                    resp.sendRedirect("./");
                    return;
                } else {
                    // Неправильный пароль
                    massage = "Wrong password";
                }
            } else {
                // Неправильный логин (ник)
                massage = "Wrong login";
            }
            //System.out.println(n);
        } catch (IOException | InstantiationException | SQLException ex) {
            System.out.println(ex.getMessage());
            massage = "ошибка смотри лог сервера";
        }

        // return View
        req.setAttribute("authMassage", massage);
        req.getRequestDispatcher("authorization.jsp").forward(req, resp);
    }

}
