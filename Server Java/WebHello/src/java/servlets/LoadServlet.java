package servlets;

import java.io.File;
import static java.io.FileDescriptor.in;
import java.io.FileInputStream;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.StandardCopyOption;
import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.Part;

/**
 *
 * @author artem
 */
public class LoadServlet extends HttpServlet {

    @Override
    protected void doPost(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {

        // Согласование кодировок - первая инструкция до начала чтения req
        req.setCharacterEncoding(StandardCharsets.UTF_8.name());
        // Извлекаем часть "userfile" - по имени <input
        Part filePart = req.getPart("clientfile");
        
        // Получаем имя файла (из заголовков)
        String fileName = null;

        // NetBeans - Ant - Java7
        // fileName = filePart.getSubmittedFileName() ;
        // альтернатива - разобрать заголовок самостоятельно
        for (String item : filePart.getHeader("Content-Disposition").split(";")) {
            String[] d = item.split("=");
            if (" filename".equals(d[0])) {
                fileName = d[1].replace("\"", "");
            }
        }

        if (fileName != null && !fileName.equals("")) {
            // Получаем путь к расположению проекта с сервлетом
            String path = getServletContext().getRealPath(".");
            // Создаем файл для сохранения переданных данных
            File updated = new File(path, fileName);
            // Копируем из потока filePart в новый файл
            Files.copy(
                    filePart.getInputStream(),
                    updated.toPath(),
                    StandardCopyOption.REPLACE_EXISTING
            );
            // удаляем временный файл
            filePart.delete();
        }

        String desc = req.getParameter("description");

        req.setAttribute("filename", fileName);   // передача данных дальше (в JSP)
        req.setAttribute("description", desc);

        RequestDispatcher disp = req.getRequestDispatcher("load.jsp");

        if (disp != null) {
            disp.forward(req, resp);
        }

    }

    @Override
    protected void doGet(
            HttpServletRequest request,
            HttpServletResponse response)
            throws ServletException, IOException {

          /*
        if(req.getParameter("my") != null){
            doMy(req,resp);
            return;
        }
        */
        // Проверяем, есть ли запрос на файл
        String filename = request.getParameter("filename");  // из ссылки ?filename=
        if (filename != null) {
            //download
            String path = getServletContext().getRealPath(".");
            File file = new File(path, filename);

            if (file.isFile()) {
                // resp.getWriter().print( "Exists" ) ;
                // piping - передача данных из потока чтения в поток записи
                // 1. Открыть потоки
                // 2. Создать буфер 
                // 3. Циклично читать в буфер из потока ч. и писать буфер в поток з.
                // read stream с форматом byte[]
                // FileReader - char[]
                // FileInputStream - byte[]   // read(byte[] b, int off, int len)
                
                FileInputStream reader = new FileInputStream(file);
                
                // write stream = resp.getOutputStream()
                // buffer
                byte[] buf = new byte[512];
                // задача - определить  Content-Type
                String type = "";
                String fileExtension = "";
                String ContenDisposition = "inline";
                // Определяем расширение файла (по подстроке после самой правой точки)
                int position = filename.lastIndexOf(".");

                if (position > 0) {
                    fileExtension = filename.substring(position + 1).toLowerCase();
                }
                // по расширению определяем contentType
                switch (fileExtension) {
                    case "png":
                    case "bmp":
                    case "gif":
                    case "webp":
                        type = "image/" + fileExtension;
                        break;
                    case "jpg":
                    case "jpag":
                        type = "image/jpeg";
                        break;
                    default:
                        type = "application/octet-stream";
                        ContenDisposition = "attachment";
                }
                ContenDisposition += "; filename=" + filename;
                
                // установка заголовков - до начала отправки
                response.setHeader("Content-Type", type);
                response.setHeader("Content-Disposition", ContenDisposition);
                response.setHeader("Content-Lenght", "" + file.length());

                // piping
                int bytesRead = -1;
                while ((bytesRead = reader.read(buf, 0, 512)) != -1) {
                    response.getOutputStream().write(buf, 0, bytesRead);
                }
            } else {
                response.getWriter().print("Not Exists");
            }
        } else {
            request.getRequestDispatcher("load.jsp").forward(request, response);
        }

    }

}
