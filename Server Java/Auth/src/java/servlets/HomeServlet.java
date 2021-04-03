package servlets;

import java.io.IOException;
import java.sql.ResultSet;
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
@WebServlet("/")
public class HomeServlet extends HttpServlet {

    @Override
    protected void doGet(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        HttpSession session = req.getSession();
       
        if(req.getParameter("logout") != null) {
            
            session.removeAttribute("authUserId");
            resp.sendRedirect("./auth");
            return;
        }
        
        if(session.getAttribute("authUserId") == null) {
            
            resp.sendRedirect("auth");
            return;
        }
        
        try {
            ResultSet res = 
                    Db.getConnection()
                    .createStatement()
                    .executeQuery("SELECT * FROM Users WHERE id="  + 
                       session.getAttribute("authUserId"));
            
            res.next();
            
            req.setAttribute("username", res.getString("name"));
            /*  set Attribute for view       */
            req.setAttribute("regdata", res.getString("moment_create"));
            req.setAttribute("lastdata", res.getString("moment_last_visit"));
            /*  finish block                 */
            
            req.setAttribute("avatar", res.getString("avatar"));
            
            System.out.println(req.getAttribute("username"));
        }  
        catch( Exception ex){
            System.out.println( ex.getMessage() ) ;
        }
   
        req.setAttribute("servlet", "ok");
        req.getRequestDispatcher("index.jsp").forward(req, resp);
    }
    
    
}
