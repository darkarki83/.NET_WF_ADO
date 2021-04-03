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
        
        String login = req.getParameter("login");
        String pass = req.getParameter("pass");
        
        String massage = null;
        
        //String hashPass = (Hasher.md5(pass + Hasher.md5(login)));
        
        //massage = login + " " + pass;
        //System.out.println(hashPass);
        
        String n = null;
        try{
            ResultSet res = Db.getConnection()
               .createStatement()
               .executeQuery("SELECT * FROM Users WHERE nik LIKE '" + login + "' " );
            
            
            if(res.next()) {
                String passHash = res.getString("pass_hash");
                String passSalt = res.getString("pass_salt");
                
                if(passHash.equals(Hasher.md5(pass + passSalt))) {
                    
                    massage = "Hi " + login;
                   
                    HttpSession session = req.getSession();
                    session.setAttribute("authUserId", res.getInt("id"));
                    session.setAttribute("name", res.getString("name"));
                   
                    /*   update last_visit                     */
                    SimpleDateFormat formatter= new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
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
                    } 
                    catch( Exception ex ) {
                        System.out.println( ex.getMessage() ) ;
                    }
                    /*  finsh block             */
                    resp.sendRedirect("./");
                    return;
                }
                else {
                    massage = "Wrong password";
                }
            }
            else {
                massage = "Wrong login";
            }
            //System.out.println(n);
        }
        catch( Exception ex){
            System.out.println( ex.getMessage() ) ;
            massage = "ошибка смотри лог сервера";
        }
       
        req.setAttribute("authMassage", massage);
        req.getRequestDispatcher("authorization.jsp").forward(req, resp);
    }

    
}
