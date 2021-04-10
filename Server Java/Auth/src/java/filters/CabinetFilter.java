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
 * Предварительные проверки для входа в кабинет пользователя
 * @author artem
 */
@WebFilter( "/cabmin" )
public class CabinetFilter implements Filter {

    FilterConfig filterConfig;
    
    @Override
    public void init(FilterConfig filterConfig) throws ServletException {
        this.filterConfig = filterConfig;
    }

    @Override
    public void doFilter(ServletRequest request, ServletResponse response, FilterChain chain) throws IOException, ServletException {
        // контроль срабатывания
        request.setAttribute("fromfilter", "Hello");
        
        HttpServletRequest req = (HttpServletRequest)request;    
        HttpServletResponse resp = (HttpServletResponse)response;
        // Ссылка на текущую сессию
        HttpSession session = req.getSession();
        // Проверяем, есть ли вообще авторизаця (сохраненная в сессии) 
        if (session.getAttribute("authUserId") != null) {
            // Запрашиваем пользователя из БД
            String uid = session.getAttribute("authUserId").toString();
            orm.User user = utilits.UserUtil.getById(uid);
            if (user != null) {
                // Сохраняем информацию в атрибутах запроса
                request.setAttribute("authUser", user);
                chain.doFilter(request, response);
                return;
            }
        }
        // Сюда попадаем если нет сессии или не найден пользователь
        resp.sendRedirect(req.getContextPath() + "/auth");
    }

    @Override
    public void destroy() {
        this.filterConfig = null;
    }
    
}
