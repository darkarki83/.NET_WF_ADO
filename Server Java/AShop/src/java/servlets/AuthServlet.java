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

/**
 *
 * @author artem
 */
@WebServlet("/auth")
public class AuthServlet extends HttpServlet {

    @Override
    protected void doGet(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        req.getRequestDispatcher("auth.jsp").forward(req, resp);
    }

    @Override
    protected void doPost(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        String login = req.getParameter("login");
        String pass = req.getParameter("pass");
        
        String massage = null;
       // Д.З. Составить код для проверки авторизации
        try {
            ResultSet res = util.Db.getConnection()
                    .createStatement()
                    .executeQuery("SELECT * FROM Users WHERE name LIKE '"
                            + login + "' ");

            if (res.next()) {
                // Есть запись с таким nik
                String passHash = res.getString("pass_hash");
                String passSalt = res.getString("pass_salt");

                if (passHash.equals(util.Hasher.md5(pass + passSalt))) {
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
                        util.Db.getConnection()
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
                    /*  finish block             */
                    resp.sendRedirect("./shop");
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
        req.getRequestDispatcher("auth.jsp").forward(req, resp);
    } 
}
