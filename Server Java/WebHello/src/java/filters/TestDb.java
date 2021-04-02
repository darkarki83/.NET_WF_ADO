package filters;

import java.io.IOException;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.servlet.Filter;
import javax.servlet.FilterChain;
import javax.servlet.FilterConfig;
import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.ServletRequest;
import javax.servlet.ServletResponse;

/**
 *
 * @author artem
 */
public class TestDb implements Filter {

    FilterConfig filterConfig;

    @Override
    public void init(FilterConfig filterConfig) throws ServletException {
        this.filterConfig = filterConfig;
    }

    @Override
    public void doFilter(
            ServletRequest request,
            ServletResponse response,
            FilterChain chain) throws IOException, ServletException {

        // Инициируем создание подключения к БД
        try {
            (new model.Db())
                    .getConnection();

        } catch (Exception ex) { // если подключение не установлено
            // Выводим в консоль сервера сообщение
            System.out.println(ex.getMessage());
            // Переводим сайт в "статический" режим
            // Сначала пробуем .jsp
            RequestDispatcher disp = request.getRequestDispatcher("static.jsp");
            if (disp != null) {
                disp.forward(request, response);
            } 
            
            return;
        }

        chain.doFilter(request, response); // Продолжение цепочки фильтров
    }

    @Override
    public void destroy() {

        this.filterConfig = null;
    }

}
