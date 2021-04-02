
package servlets;

import java.io.IOException;
import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

/**
 *
 * @author arte
 */
public class NewsServlets extends HttpServlet {

    //routing
    @Override
    protected void doGet(
            HttpServletRequest request, 
            HttpServletResponse response) 
            throws ServletException, IOException {
        
        
        // перенапровление
        RequestDispatcher disp = request.getRequestDispatcher("news.jsp");
        if(disp != null) {
            disp.forward(request, response);
        }
    }
    
    
    
}
