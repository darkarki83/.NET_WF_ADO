package servlets;

import java.io.IOException;
import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

/**
 *
 * @author artem
 */

// Протокол - набор правил
// Физический протокол - набора правил для сигналов (частоты, напряжения)
// Транспортный протокол - набор правил для передачи данных (бит, байт)
// Прикладной протокол - для обработки данных (кодировка, структура)

public class UsersServlet extends HttpServlet {

    @Override
    protected void doGet(
            HttpServletRequest request,
            HttpServletResponse response)
            throws ServletException, IOException {

        RequestDispatcher disp = request.getRequestDispatcher("index.jsp");
        if (disp != null) {
            disp.forward(request, response);
        }

    }
}
