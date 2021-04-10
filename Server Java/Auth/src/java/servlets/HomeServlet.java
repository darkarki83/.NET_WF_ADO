package servlets;

import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.sql.ResultSet;
import java.sql.SQLException;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;
import utilits.Db;

/**
 *
 * @author artem
 */
//@WebServlet("/home")
@WebServlet("/")
public class HomeServlet extends HttpServlet {

    @Override
    protected void doGet(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {

        String path = getServletContext().getRealPath(".");
        String filename = req.getServletPath();
        File file = new File(path, req.getServletPath());

        if (file.isFile()) {

            String fileExtension = "";
            String ContenDisposition = "inline";
            // Определяем расширение файла (по подстроке после самой правой точки)
            int position = filename.lastIndexOf(".");

            if (position > 0) {
                fileExtension = filename.substring(position + 1).toLowerCase();
            }
            if (fileExtension.equals("css")) {
                resp.setHeader("Content-Type", "text/css");
                
            } else {
                resp.setHeader("Content-Type", "application/octet-stream");

            }

            FileInputStream reader = new FileInputStream(file);
            byte[] buf = new byte[512];
            // задача - определить  Content-Type

            int bytesRead = -1;
            while ((bytesRead = reader.read(buf, 0, 512)) != -1) {
                resp.getOutputStream().write(buf, 0, bytesRead);
            }
            return;
        }

        HttpSession session = req.getSession();

        if (req.getParameter("logout") != null) {

            session.removeAttribute("authUserId");
            resp.sendRedirect(req.getContextPath() + "/auth");
            return;
        }

        if (session.getAttribute("authUserId") == null) {

            /*resp.sendRedirect("auth");
            System.out.println(req.getServerName());
            System.out.println(req.getRequestURI());
            System.out.println(req.getServletPath());
            System.out.println(req.getContextPath());*/
            resp.sendRedirect(req.getContextPath() + "/auth");
            return;
        }

        try {
            ResultSet res
                    = Db.getConnection()
                            .createStatement()
                            .executeQuery("SELECT * FROM Users WHERE id="
                                    + session.getAttribute("authUserId"));

            res.next();

            req.setAttribute("username", res.getString("name"));
            /*  set Attribute for view       */
            req.setAttribute("regdata", res.getString("moment_create"));
            req.setAttribute("lastdata", res.getString("moment_last_visit"));
            /*  finish block                 */

            req.setAttribute("avatar", res.getString("avatar"));

            //System.out.println(req.getAttribute("username"));
        } catch (InstantiationException | SQLException ex) {
            System.out.println(ex.getMessage());
        }

        req.setAttribute("servlet", "ok");
        req.getRequestDispatcher("index.jsp").forward(req, resp);
    }

}
