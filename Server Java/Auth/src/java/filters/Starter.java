package filters;

import java.io.IOException;
import javax.servlet.Filter;
import javax.servlet.FilterChain;
import javax.servlet.FilterConfig;
import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.ServletRequest;
import javax.servlet.ServletResponse;
import javax.servlet.annotation.WebFilter;
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
        
        request.setAttribute("fromstarter", "Hello0");
        
        chain.doFilter(request, response);
    }

    @Override
    public void destroy() {
        this.filterConfig = null;
    }
    
}
