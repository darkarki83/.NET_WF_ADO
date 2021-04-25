package servlets;

import java.io.IOException;
import java.util.ArrayList;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

/**
 *
 * @author artem
 */
@WebServlet("/adminusers")
public class AdminUserServlet extends HttpServlet {

    @Override
    protected void doGet(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        
        ArrayList<orm.User> users = util.UserUtil.getListUser();
        
        req.setAttribute("users", users);
        req.getRequestDispatcher("adminusers.jsp").forward(req, resp);
    }

    @Override
    protected void doDelete(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
         String uid = req.getParameter("uid");

        if (uid == null) {

            resp.getWriter().print(" { \"status\" : \"error\", \"msg\" : \"User id not defind\" } ");   // { "status":"error", "msg":"msg" }
        } else {
            if (util.UserUtil.deleteById(req.getParameter("uid"))) {
                resp.getWriter().print(" { \"status\" : \"success\", \"msg\" : \"User deleted\" } ");
            } else {
                resp.getWriter().print(" { \"status\" : \"error\", \"msg\" : \"Inner error. See server log \" } ");
            }
        }
    }

    @Override
    protected void doPost(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
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
        if(uid == null) {
            resp.getWriter().print(" { \"status\" : \"error\", \"msg\" : \"User id not defind\" } ");
            return;
        }
        else if(roleId == null) {
            resp.getWriter().print(" { \"status\" : \"error\", \"msg\" : \"RoleId not defind\" } ");
            return;
        }
        else {
            if(util.UserUtil.updateById(uid, roleId)) {
               resp.getWriter().print(" { \"status\" : \"success\", \"msg\" : \"User update\" } ");
            }
            else {
                resp.getWriter().print(" { \"status\" : \"error\", \"msg\" : \"Inner error. See server log\" } ");
            }
        }
    }  
}
