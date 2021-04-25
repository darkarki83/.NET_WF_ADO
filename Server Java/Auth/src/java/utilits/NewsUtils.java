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

       
            ArrayList<orm.News> news = new ArrayList<>();
            try {
                ResultSet res = Db.getConnection()
                        .createStatement()
                        .executeQuery("SELECT * FROM news");
                news = new ArrayList<>();
                while (res.next()) {
                    news.add(new orm.News(
                            res.getInt("id"),
                            res.getString("title"),
                            res.getString("content_short"),
                            res.getString("content_full"),
                            res.getDate("moment"),
                            res.getInt("id_author"),
                            res.getString("avatar"),
                            res.getInt("blocked"),
                            res.getString("blocked_reason")
                    ));
                }
            } catch (InstantiationException | SQLException ex) {
                System.out.println("getList" + ex.getMessage());
                return null;
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
                        res.getString("avatar"),
                        res.getInt("blocked"),
                        res.getString("blocked_reason")
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
                            + "LEFT JOIN Users U ON U.id=C.id_author WHERE C.blocked IS NULL AND C.id_news="
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
    
    public static ArrayList<orm.NewsComment> getCommentsList() {
         try {
            ResultSet res = Db.getConnection()
                    .createStatement()
                    .executeQuery(
                            "SELECT C.*, U.nik FROM News_comments C "
                            + "LEFT JOIN Users U ON U.id=C.id_author");

            ArrayList<orm.NewsComment> newsCommints = new ArrayList<>();

            while (res.next()) {
                newsCommints.add(new orm.NewsComment(
                        res.getInt("id"),
                        res.getInt("id_author"),
                        res.getInt("id_news"),
                        res.getInt("id_ref"),
                        res.getDate("moment"),
                        res.getString("comment"),
                        res.getString("nik"),
                        res.getInt("blocked")
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
    
    public static boolean disableComment(String idCommit) {
    
        String query = 
                "UPDATE news_comments SET blocked=if(blocked =1, null, 1) WHERE id =" + idCommit;
        try {
            Db.getConnection()
                    .createStatement()
                    .executeUpdate(query);
        } 
        catch (InstantiationException | SQLException ex) {
            System.out.println(" NewsUtils disableComment" + 
                    ex.getMessage()  + query);
            return false;
        }
        return true;
    }
    
    public static boolean disableNews(String idNews, String reason) {
    
        String query = 
                "UPDATE news SET blocked=if(blocked =1, null, 1), blocked_reason= '" + reason +  "' WHERE id =" + idNews;
        try {
            Db.getConnection()
                    .createStatement()
                    .executeUpdate(query);
        } 
        catch (InstantiationException | SQLException ex) {
            System.out.println(" NewsUtils disableNews" + 
                    ex.getMessage()  + query);
            return false;
        }
        return true;
    }
    
     public static boolean addNews(String title, String content_short, String content_full, String avatarName, int uid) {
    
        String query = 
                "INSERT INTO news (title, content_short, content_full, id_author, avatar) "
                + "VALUES( '" + title.replace("'", "\\'") + "', '" + content_short.replace("'", "\\'") + "', '" + content_full.replace("'", "\\'")
                + "', " + uid + ", " + avatarName + " )";

        try {
            Db.getConnection()
                    .createStatement()
                    .executeUpdate(query);
        } 
        catch (InstantiationException | SQLException ex) {
            System.out.println(" NewsUtils addNews" + 
                    ex.getMessage()  + query);
            return false;
        }
        return true;
    }
}
