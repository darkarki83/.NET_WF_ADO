package servlets;

import java.io.IOException;
import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;
import java.util.logging.Level;
import java.util.logging.Logger;
import java.util.stream.Collectors;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.xml.bind.DatatypeConverter;

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

        
        // передача тела блокируется браузером, имеем только URL параметры
        String x = request.getParameter("x");
        String y = request.getParameter("y");
        response.getWriter().print("GET API : x = " + x + " y = " + y);

    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

         // Принимает и тело, и URL параметры,
        // req.getParameter анализирует URL и тело, после чего тело становится
        // недоступным для повторного считывания
        
        /*
        // POST ищет данные и в GET и в теле, тем самым считывая тело
        String x = req.getParameter( "x" ) ;
        String y = req.getParameter( "y" ) ;
        resp.getWriter().println( "POST API: x = " + x + ", y = " + y ) ;
        // повторное чтение тела невозможно
        String body = req.getReader().lines().collect( Collectors.joining() ) ;
        resp.getWriter().println( " body : " + body ) ;
        */
        // Первое обращение к телу
        String body = request.getReader().lines().collect(Collectors.joining());
        response.getWriter().println("Body : " + body);

        // второе
        String x = request.getParameter("x");
        String y = request.getParameter("y");
        response.getWriter().println("POST API : x = " + x + " y = " + y);

        response.getWriter().println(request.getQueryString());
    }

    @Override
    protected void doPut(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        // Принимает и тело, и URL параметры, но req.getParameter анализирует только URL
        String x = request.getParameter("x");
        String y = request.getParameter("y");
        response.getWriter().println("PUT API : x = " + x + " y = " + y);

        String body = request.getReader().lines().collect(Collectors.joining());
        response.getWriter().println("Body : " + body);

        // Хеширование - эволюция контрольной суммы - необратимое преобразование
        // постоянной длины (размера), получающее хеш-образ исходного объекта
        // В веб-разработке хеш используется для хранения паролей
        // ! В БД нельзя хранить пароли в открытом виде
        // Современные хеши - это раздел криптографии, преобразование [бит]->[бит]
        // MessageDigest - java.security.MessageDigest - инструмент для хеширования
        // Криптосоль - примесь случайных данных к исходной строке
        
        //MessageDigest => import java.security.MessageDigest;
        String salt = "54321";
        byte[] info = (body+ salt).getBytes();
        MessageDigest hasher1;
        MessageDigest hasher2;
        MessageDigest hasher3;

        try {// создаем реализацию дайджеста
            hasher1 = MessageDigest.getInstance("MD5");
            hasher2 = MessageDigest.getInstance("SHA-1");
            hasher3 = MessageDigest.getInstance("SHA-256");
        }
        catch (NoSuchAlgorithmException ex) {
            response.getWriter().println(ex.getMessage());
            return;
        }

        byte[] hash1 = hasher1.digest(info);
        byte[] hash2 = hasher2.digest(info);
        byte[] hash3 = hasher3.digest(info);

        String hashString1 = DatatypeConverter.printHexBinary(hash1);
        String hashString2 = DatatypeConverter.printHexBinary(hash2);
        String hashString3 = DatatypeConverter.printHexBinary(hash3);

        response.getWriter().println("hash MD5 : " + hashString1);
        response.getWriter().println("hash SHA-1 : " + hashString2);
        response.getWriter().println("hash SHA-256 : " + hashString3);
    }

    @Override
    protected void doDelete(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

        // Принимает только URL параметры, тело не допускается
        String x = request.getParameter("x");
        String y = request.getParameter("y");
        response.getWriter().print("DELETE API : x = " + x + " y = " + y);
    }

    @Override
    protected void doHead(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

        String x = request.getParameter("x");
        String y = request.getParameter("y");
        response.getWriter().print("HEAD API : x = " + x + " y = " + y);
    }

}
