package filters;

import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import javax.servlet.Filter;
import javax.servlet.FilterChain;
import javax.servlet.FilterConfig;
import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.ServletRequest;
import javax.servlet.ServletResponse;
import javax.servlet.annotation.WebFilter;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;
import utilits.Db;

/**
 *
 * @author artem
 */
@WebFilter("/*")
public class Starter implements Filter {

    FilterConfig filterConfig;
    
    @Override
    public void init(FilterConfig filterConfig) throws ServletException {
        this.filterConfig = filterConfig;
    }

    @Override
    public void doFilter(ServletRequest request, ServletResponse response, FilterChain chain) throws IOException, ServletException {
        // only look
        System.out.println("Filter Works");
        
        // Проверяем возможность подключения к БД
        try {
            Db.getConnection();
        } catch (InstantiationException ex) {
            
            System.out.println(ex.getMessage());
            // нет подключения - переход в "статический" режим
            request
                    .getRequestDispatcher("index.html")
                   .forward(request, response);
            return;
        }
        
        request.setCharacterEncoding( "UTF8" ); 
        response.setCharacterEncoding( "UTF8" ); 
        
        // контроль срабатывания
        //request.setAttribute("fromstarter", "Hello0");
        
        HttpServletRequest req = (HttpServletRequest) request ;
        HttpServletResponse resp = (HttpServletResponse) response ;
        
        // Установленный на все адреса сервлет перехватывает обращение к файлам
        // В таком случае, к задачам сервлета следует отнести загрузку файла,
        // на такие запросы
        String path = req.getServletContext().getRealPath( "." ) ;
        String filename = req.getServletPath() ;
        File file = new File( path, filename ) ;
        if( file.isFile() ) {
            // Запрос - на существующий файл
            // -- Место для проверок на допустимость --
            // некоторые запросы чувствительны к Content-Type, например, css
            // определяем расширение файла
            String fileExtension = "" ;
            int pos = filename.lastIndexOf( '.' ) ;
            if( pos >= 0 ) fileExtension = filename.substring( pos + 1 ).toLowerCase() ;
            // по расширению определяем contentType
            if( fileExtension.equals( "css" ) ) {
                resp.setHeader( "Content-Type", "text/css" ) ;
            } else if( fileExtension.equals( "html" ) ) {
                resp.setHeader( "Content-Type", "text/html" ) ;
            } else {
                resp.setHeader( "Content-Type", "application/octet-stream" ) ;
            }
            FileInputStream reader = new FileInputStream( file ) ;
            byte[] buf = new byte[512] ;
            int bytesRead = -1 ;
            while( ( bytesRead = reader.read( buf, 0, 512 ) ) != -1 ) {
                resp.getOutputStream().write( buf, 0, bytesRead ) ;
            }
            return;
        }
        
        HttpSession session = req.getSession() ;

        // Если есть запрос на отключение (выход)
        if( req.getParameter( "logout" ) != null ) {
            session.removeAttribute( "authUserId" ) ;
            resp.sendRedirect( req.getContextPath() + "/auth" ) ;
            return ;
        }       

        orm.User authUser = null ;  // Ссылка на "вошедшего" пользователя
        // Проверяем авторизацию (сохраненную в сессии)
        if( session.getAttribute( "authUserId" ) != null ) {
            // Если в сессии сохранен id пользователя, получаем полные данные из БД
            authUser = utilits.UserUtil.getById(
                    session.getAttribute( "authUserId" ).toString()
            ) ;            
        }
        
        // Запоминаем данные о пользователе в запросе
        req.setAttribute( "authUser", authUser ) ;
        
        // создаем исключения для страниц, не требующих авторизации
        if( authUser == null ) {
            if( req.getServletPath().startsWith( "/news" )
             || req.getServletPath().startsWith( "/auth" ) ) {
                // Прекращаем работу данного сервлета (включатся следующие)
                chain.doFilter( request, response ) ;
                return ;
            } else {  
                // Остальные страницы недоступны без авторизации
                resp.sendRedirect( req.getContextPath() + "/auth" ) ;
                return ;
            }
        } else {
            chain.doFilter( request, response ) ;
        }
        
    }

    @Override
    public void destroy() {
        this.filterConfig = null;
    }
    
}
