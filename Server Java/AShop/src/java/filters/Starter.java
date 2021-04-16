package filters;

import java.io.IOException;
import javax.servlet.Filter;
import javax.servlet.FilterChain;
import javax.servlet.FilterConfig;
import javax.servlet.ServletException;
import javax.servlet.ServletRequest;
import javax.servlet.ServletResponse;
import javax.servlet.annotation.WebFilter;



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
        
        request.setAttribute("test", "ok");
        request.getRequestDispatcher("index.jsp").forward(request, response);
        chain.doFilter( request, response ) ;
    }

    @Override
    public void destroy() {
        this.filterConfig = null;

    }
    
}
