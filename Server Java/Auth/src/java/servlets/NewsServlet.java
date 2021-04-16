/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package servlets;

import java.io.File;
import java.io.IOException;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.Arrays;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

/**
 *
 * @author artem
 */
@WebServlet("/news/*")
public class NewsServlet extends HttpServlet {

    private static final long serialVersionUID = 1L;


    @Override
    protected void doGet(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {

        String[] uriParts = req.getRequestURI().split("/");

        if (uriParts.length < 4) {
            ArrayList<orm.News> news = utilits.NewsUtils.getList();

            if (news != null) {
                req.setAttribute("news", news);
            }
            req.getRequestDispatcher("/news.jsp").forward(req, resp);
        } else {
            int newsId = 0;

            try {
                newsId = Integer.parseInt(uriParts[3]);
            } catch (NumberFormatException ex) {
                System.out.println("News-Servlet-doGet-parseInt: " + ex.getMessage());
                resp.setStatus(404);
                return;
            }
            orm.News news = utilits.NewsUtils.getById(newsId);
            if (news == null) {
                resp.setStatus(404);
                return;
            }
            req.setAttribute("theNews", news);
            
            orm.User author = utilits.UserUtil.getById(news.getIdAuthor());
            req.setAttribute("theNewsAuthor", author);
            
            ArrayList<orm.NewsComment> comments = 
                    utilits.NewsUtils.getCommentsList(news.getId());
            req.setAttribute("theNewsComments", comments);
            
            req.getRequestDispatcher("/newsdatails.jsp").forward(req, resp);
        }

    }

    @Override
    protected void doPost(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        String newsId = req.getParameter("idNews");
        String authorId = req.getParameter("idAuthor");
        String txt = req.getParameter("txt");
        
        if(newsId == null || authorId == null || txt == null) {
            resp.getWriter().print("-1");
            return;
        }
        
        int idNews = 0;
        int idAuthor = 0;
        try {
            idNews = Integer.parseInt(newsId);
            idAuthor = Integer.parseInt(authorId);  
        }
        catch (NumberFormatException ex) {
            System.out.println("NewsServlet-doPost" +  ex.getMessage());
            resp.getWriter().print("-2");
            return;
        }
        if(utilits.NewsUtils.addComment(idNews, idAuthor, txt)){
            resp.getWriter().print("1");
        }
        else {
            resp.getWriter().print("-3");
        }
    }
}
