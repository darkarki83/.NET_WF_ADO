package servlets;

import java.io.File;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.StandardCopyOption;
import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import javax.servlet.ServletException;
import javax.servlet.annotation.MultipartConfig;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.Part;
import utilits.Db;
import utilits.Hasher;

/**
 *
 * @author artem
 */

@WebServlet("/reg")
@MultipartConfig
public class RegServlet extends HttpServlet {

    @Override
    protected void doGet(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        req.getRequestDispatcher("registration.jsp").forward(req, resp);
    }
    
    @Override
    protected void doPost(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        
        /* проверка есть ли такой ник      */
        String massage = null;
        
        String usernik = req.getParameter("usernik");
        int n = -1;
        
        try{
             ResultSet res = 
                     Db.getConnection()
                    .createStatement()
                    .executeQuery("SELECT COUNT(*) FROM Users WHERE nik LIKE '" + usernik + "' " );
            
             res.next();
             n = res.getInt(1);        
        }
        catch( Exception ex){
            System.out.println( ex.getMessage() ) ;
            massage = "ошибка смотри лог сервера";
        }
        
        if(n != 0) {
            massage = "Есть такой ник";
            
            req.setAttribute("regMassage", massage);
            req.getRequestDispatcher("registration.jsp").forward(req, resp);
            return;
        }
        /* с перенапровлением сюдаже */
        
        
        /* работа с фоткой 
            1) достаем имя
            2) если есть делим имя на части
            3) проверка есть ли такой фаил в папки
            4) если есть добавляем 1 к имени
            5) добавка в папку
        */
        Part avatar = req.getPart("useravatar");
        
        //1) достаем имя
        String avatarName = avatar.getSubmittedFileName();
        
        String savedName = null;
        String savedExt = null;
        
        // 2) если есть делим имя на части
        if(!"".equals(avatarName)) {
            
            String path = getServletContext().getRealPath("./../../web/avatars");
            // Создаем файл для сохранения переданных данных
            
            int dotPotition = avatarName.lastIndexOf(".");
            String baseName = avatarName.substring(0, dotPotition);
            savedExt = avatarName.substring(dotPotition + 1);
            
            savedName = baseName;
            
            File updated = new File(path, savedName + "." + savedExt);
            // Копируем из потока filePart в новый файл
             
            //3) проверка есть ли такой фаил в папки
            int i = 1;
            while(updated.isFile()) {
                //4) если есть добавляем 1 к имени
                savedName = baseName + i;
                updated = new File( path, savedName + "." + savedExt);
                i++;
            }
            
            // 5) добавка в папку
            Files.copy( 
                    avatar.getInputStream(),
                    updated.toPath(),
                    StandardCopyOption.REPLACE_EXISTING
            );
            // удаляем временный файл
            avatar.delete(); 
        }
        
        /* параметры из формы    */
        
        String name = req.getParameter("username");
        String userpass = req.getParameter("userpass");
        String useremail = req.getParameter("useremail");
        /* создание соли и хэша   */
        String salt =  Hasher.md5(usernik);
        String hash = Hasher.md5(userpass + salt);

        /* добавляем в базу       */
        try{
            Db.getConnection()
                    .createStatement()
                    .executeUpdate(
                            String.format(
                                    "INSERT INTO Users(name,nik,pass_hash,pass_salt,email,avatar)"
                                            + " VALUES("
                                            + " '%s', '%s', '%s', '%s', '%s', %s)",
                            name,
                            usernik,
                            hash,
                            salt,
                            useremail,
                            (savedName == null) ? "null" : "'" + savedName + "." + savedExt  + "'"
                            ));
            massage = String.format("Регистрация %s (aka %s) прошла успешна", name, usernik);
        }
        catch( Exception ex ) {
            System.out.println( ex.getMessage() ) ;
            massage = "ошибка смотри лог сервера";

        }
        
        req.setAttribute("regMassage", massage);
        req.getRequestDispatcher("registration.jsp").forward(req, resp);
        
        
        /*  //просто проверка 
        System.out.println(name);
        System.out.println(usernik);
        System.out.println(Hasher.md5(userpass + salt));
        System.out.println(salt);
        System.out.println(useremail);
        System.out.println(avatarName);
        */
    }
 
}
