package servlets;

import java.io.IOException;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;
import utilits.Db;
import utilits.UserUtil;

/**
 *
 * @author artem
 */
@WebServlet("/admin")
public class AdminServlet extends HttpServlet {

    /**
     *
     * @param req
     * @param resp
     * @throws ServletException
     * @throws IOException
     */
    @Override
    protected void doGet(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        // ~Добавить проверку авторизации на все методы (см. ДЗ *****) 
        // doing Admin Filter

        ArrayList<orm.User> users = new ArrayList<>();

        try {
            ResultSet res = Db.getConnection()
                    .createStatement()
                    .executeQuery("SELECT * FROM Users");

            while (res.next()) {
                users.add(new orm.User(res.getInt("id"),
                        res.getString("name"),
                        res.getString("nik"),
                        res.getString("email"),
                        res.getString("avatar"),
                        res.getDate("moment_create"),
                        res.getDate("moment_last_visit"),
                        res.getInt("id_role")
                ));
            }
        } catch (InstantiationException | SQLException ex) {
            System.out.println(ex.getMessage());
            return;
        }

        req.setAttribute("users", users);
        req.getRequestDispatcher("adminusers.jsp").forward(req, resp);
    }

    @Override
    protected void doDelete(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        
        String uid = req.getParameter("uid");

        if (uid == null) {

            resp.getWriter().print(" { \"status\" : \"error\", \"msg\" : \"User id not defind\" } ");   // { "status":"error", "msg":"msg" }
        } else {
            if (UserUtil.deleteById(req.getParameter("uid"))) {
                resp.getWriter().print(" { \"status\" : \"success\", \"msg\" : \"User deleted\" } ");
            } else {
                resp.getWriter().print(" { \"status\" : \"error\", \"msg\" : \"Inner error. See server log \" } ");
            }
        }
    }

    @Override
    protected void doPost(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        // Прием изменений в роли пользователя
        String uid = req.getParameter("uid");
        String roleId = req.getParameter("id_role");

        if (uid.contains("'") || uid.contains(" ")) {
            resp.getWriter().print(" { \"status\" : \"error\", \"msg\" : \"User id not defind\" } ");   // { "status":"error", "msg":"msg" }
            return;
        }
        if (roleId.contains("'") || roleId.contains(" ")) {
            resp.getWriter().print(" { \"status\" : \"error\", \"msg\" : \"User id not defind\" } ");   // { "status":"error", "msg":"msg" }
            return;
        }

        if (uid == null) {

            resp.getWriter().print(" { \"status\" : \"error\", \"msg\" : \"User id not defind\" } ");   // { "status":"error", "msg":"msg" }
            return;
        } else if (roleId == null) {

            resp.getWriter().print(" { \"status\" : \"error\", \"msg\" : \"RoleId not defind\" } ");   // { "status":"error", "msg":"msg" }
            return;
        } else {
            if (UserUtil.updateById(uid, roleId)) {
                resp.getWriter().print(" { \"status\" : \"success\", \"msg\" : \"User update\" } ");
            } else {
                resp.getWriter().print(" { \"status\" : \"error\", \"msg\" : \"Inner error. See server log \" } ");
            }
        }
    }
}
