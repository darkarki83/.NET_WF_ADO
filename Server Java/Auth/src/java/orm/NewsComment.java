package orm;

import java.sql.Date;

/**
 *
 * @author artem
 */
public class NewsComment {
    int id;
    int idAuthor;
    int idNews;
    int idRef;
    Date moment;
    String commint;
    String authorNik;
    int blocked;

    public NewsComment(int id, int idAuthor, int idNews, int idRef, Date moment, String commint, String authorNik, int blocked) {
        this.id = id;
        this.idAuthor = idAuthor;
        this.idNews = idNews;
        this.idRef = idRef;
        this.moment = moment;
        this.commint = commint;
        this.authorNik = authorNik;
        this.blocked = blocked;
    }
    
    public NewsComment(int id, int idAuthor, int idNews, int idRef, Date moment, String commint, String authorNik) {
        this.id = id;
        this.idAuthor = idAuthor;
        this.idNews = idNews;
        this.idRef = idRef;
        this.moment = moment;
        this.commint = commint;
        this.authorNik = authorNik;
    }

    public NewsComment() {
    }

    public void setId(int id) {
        this.id = id;
    }

    public void setIdAuthor(int idAuthor) {
        this.idAuthor = idAuthor;
    }

    public void setIdNews(int idNews) {
        this.idNews = idNews;
    }

    public void setIdRef(int idRef) {
        this.idRef = idRef;
    }

    public void setMoment(Date moment) {
        this.moment = moment;
    }

    public void setCommint(String commint) {
        this.commint = commint;
    }

    public void setBlocked(int blocked) {
        this.blocked = blocked;
    }

    public int getId() {
        return id;
    }

    public int getIdAuthor() {
        return idAuthor;
    }

    public int getIdNews() {
        return idNews;
    }

    public int getIdRef() {
        return idRef;
    }

    public Date getMoment() {
        return moment;
    }

    public String getCommint() {
        return commint;
    }

    public String getAuthorNik() {
        return authorNik;
    }
    
    public int getBlocked() {
        return blocked;
    }
}
