package servlets;

import java.io.IOException;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

/**
 *
 * @author artem
 */
public class APIServlet extends HttpServlet {

    @Override
    protected void doGet(
            HttpServletRequest request, 
            HttpServletResponse response) 
            throws ServletException, IOException {
        
        String x = request.getParameter("x");
        String y = request.getParameter("y");
        response.getWriter().print("GET API : x = " + x + " y = " + y);
    }
    
    
}
