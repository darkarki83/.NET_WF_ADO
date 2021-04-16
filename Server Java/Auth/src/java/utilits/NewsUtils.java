/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package utilits;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;

/**
 *
 * @author artem
 */
public class NewsUtils {

    public static ArrayList<orm.News> news;

    public static ArrayList<orm.News> getList() {

        if (news == null) {
            news = new ArrayList<>();
            try {
                ResultSet res = Db.getConnection()
                        .createStatement()
                        .executeQuery("SELECT * FROM news");

                while (res.next()) {
                    news.add(new orm.News(
                            res.getInt("id"),
                            res.getString("title"),
                            res.getString("content_short"),
                            res.getString("content_full"),
                            res.getDate("moment"),
                            res.getInt("id_author"),
                            res.getString("avatar")
                    ));
                }
            } catch (InstantiationException | SQLException ex) {
                System.out.println("getList" + ex.getMessage());
                return null;
            }
        }
        return news;
    }

    public static orm.News getById(int newsId) {

        try {
            ResultSet res = Db.getConnection()
                    .createStatement()
                    .executeQuery("SELECT * FROM news WHERE id=" + newsId);

            if (res.next()) {
                return new orm.News(
                        res.getInt("id"),
                        res.getString("title"),
                        res.getString("content_short"),
                        res.getString("content_full"),
                        res.getDate("moment"),
                        res.getInt("id_author"),
                        res.getString("avatar")
                );
            }
        } catch (InstantiationException | SQLException ex) {
            System.out.println("News Servlet getById " + ex.getMessage());
        }
        return null;
    }

    public static ArrayList<orm.NewsComment> getCommentsList(int newsId) {
        try {
            ResultSet res = Db.getConnection()
                    .createStatement()
                    .executeQuery(
                            "SELECT C.*, U.nik FROM News_comments C "
                            + "LEFT JOIN Users U ON U.id=C.id_author WHERE C.id_news="
                            + newsId);

            ArrayList<orm.NewsComment> newsCommints = new ArrayList<>();

            while (res.next()) {
                newsCommints.add(new orm.NewsComment(
                        res.getInt("id"),
                        res.getInt("id_author"),
                        res.getInt("id_news"),
                        res.getInt("id_ref"),
                        res.getDate("moment"),
                        res.getString("comment"),
                        res.getString("nik")
                ));
            }
            return newsCommints;
        } catch (InstantiationException | SQLException ex) {
            System.out.println("NewUtil-getCommentsList(): " + ex.getMessage());
        }
        return null;
    }

    public static ArrayList<orm.NewsComment> getCommentsList(orm.News news) {
        ArrayList<orm.NewsComment> newsCommints = NewsUtils.getCommentsList(news.getId());
        return newsCommints;
    }

    public static boolean addComment(int idNews, int idAuthor, String txt) {
        String query = 
                "INSERT INTO News_comments(id_author, id_news, comment)"
                            + "VALUES( " + idAuthor + ", " + idNews + ", '" + txt + "' )";
        try {
            Db.getConnection()
                    .createStatement()
                    .executeUpdate(query);
        } 
        catch (InstantiationException | SQLException ex) {
            System.out.println(" NewsUtils addComment" + 
                    ex.getMessage()  + query);
            return false;
        }
        return true;
    }
}
