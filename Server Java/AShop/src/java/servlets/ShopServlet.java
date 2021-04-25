
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

/**
 *
 * @author artem
 */
@WebServlet("/shop/*")
public class ShopServlet extends HttpServlet {

    @Override
    protected void doGet(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
       
         String[] uriParts = req.getRequestURI().split("/");

        if (uriParts.length < 4) {
            ArrayList<orm.Product> products = 
                    util.ProductUtil.getList();

            if (products != null) {
                req.setAttribute("theProducts", products);
            }
            req.getRequestDispatcher("/index.jsp").forward(req, resp);
        } else {
            int newsId = 0;

            try {
                newsId = Integer.parseInt(uriParts[3]);
            } catch (NumberFormatException ex) {
                System.out.println("ShopServlet 1 " + ex.getMessage());
                resp.setStatus(404);
                return;
            }
            orm.Product product = util.ProductUtil.getById(newsId);
            if (product == null) {
                resp.setStatus(404);
                return;
            }
            req.setAttribute("theProduct", product);
            
            orm.User author = util.UserUtil.getById(product.getUserId());
            req.setAttribute("theProductAuthor", author);
            
            ArrayList<orm.ProductComment> comments = 
                    util.ProductUtil.getCommentsList(product.getId());
            req.setAttribute("theProductComments", comments);
            
            req.getRequestDispatcher("/productdatails.jsp").forward(req, resp);
        }
    }

    @Override
    protected void doPost(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        
        String productId = req.getParameter("idProduct");
        String authorId = req.getParameter("idAuthor");
        String txt = req.getParameter("txt");
        
        if(productId == null || authorId == null || txt == null) {
            resp.getWriter().print("-1");
            return;
        }
        
        int idProduct = 0;
        int idAuthor = 0;
        try {
            idProduct = Integer.parseInt(productId);
            idAuthor = Integer.parseInt(authorId);  
        }
        catch (NumberFormatException ex) {
            System.out.println("NewsServlet-doPost" +  ex.getMessage());
            resp.getWriter().print("-2");
            return;
        }
        if(util.ProductUtil.addComment(idProduct, idAuthor, txt)){
            resp.getWriter().print("1");
        }
        else {
            resp.getWriter().print("-3");
        }
    }
    
    
    
    
   
    
}
