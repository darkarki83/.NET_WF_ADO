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
import javax.servlet.http.HttpSession;

/**
 *
 * @author artem
 */
//@WebFilter("/adminusers")
public class AdminUserFilter implements Filter {

   FilterConfig filterConfig;
    @Override
    public void init(FilterConfig filterConfig) throws ServletException {
        this.filterConfig = filterConfig;
    }

    @Override
    public void doFilter(ServletRequest request, ServletResponse response, FilterChain chain) throws IOException, ServletException {
        HttpServletRequest req = (HttpServletRequest)request;     
        HttpServletResponse resp = (HttpServletResponse)response;
        
        HttpSession session = req.getSession();

        if (session.getAttribute("authUserId") == null) {
            
            resp.sendRedirect(req.getContextPath() + "/auth");
            return;
        }

        String uid = session.getAttribute("authUserId").toString();
        orm.User user = util.UserUtil.getById(uid);
        
        if (user == null || user.getRoleFk() != 1) {
            resp.sendRedirect(req.getContextPath() + "/auth");
            return;
        }
    
        chain.doFilter(request, response);
    }

    @Override
    public void destroy() {
        this.filterConfig = null;
    }
    
}
