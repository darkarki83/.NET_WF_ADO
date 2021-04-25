package filters;

import java.io.IOException;
import javax.servlet.Filter;
import javax.servlet.FilterChain;
import javax.servlet.FilterConfig;
import javax.servlet.ServletException;
import javax.servlet.ServletRequest;
import javax.servlet.ServletResponse;
import javax.servlet.annotation.WebFilter;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

/**
 *
 * @author artem
 */
//@WebFilter("/moder/*")
public class ModeratorFilter implements Filter {

    FilterConfig filterConfig;
    
    @Override
    public void init(FilterConfig filterConfig) throws ServletException {
        this.filterConfig = filterConfig;
    }

    @Override
    public void doFilter(ServletRequest request, ServletResponse response, FilterChain chain) throws IOException, ServletException {
        orm.User user = (orm.User)request.getAttribute("authUser");
        
        HttpServletRequest req = (HttpServletRequest) request ;
        HttpServletResponse resp = (HttpServletResponse) response ;
        
        if(user == null || user.getRoleFk() != 2) {
            resp.sendRedirect( req.getContextPath() + "/auth" ) ;
            return ;
        }
        
        System.out.println("ModeraterFilter - User " + user.getName());
       
        chain.doFilter(request, response);
    }

    @Override
    public void destroy() {
        this.filterConfig = null;
    }
    
    
}
