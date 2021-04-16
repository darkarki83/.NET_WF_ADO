/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package orm;

import java.sql.Date;

/**
 *
 * @author artem
 */
public class News {
    int id;
    String title;
    String contentShort;
    String contentFull;
    Date moment;
    int idAuthor;
    String avatar;

    public News(int id, String title, String contentShort, String contentFull, Date moment, int idAuthor, String avatar) {
        this.id = id;
        this.title = title;
        this.contentShort = contentShort;
        this.contentFull = contentFull;
        this.moment = moment;
        this.idAuthor = idAuthor;
        this.avatar = avatar;
    }

    public News() {
    }

    public void setId(int id) {
        this.id = id;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public void setContentShort(String contentShort) {
        this.contentShort = contentShort;
    }

    public void setContentFull(String contentFull) {
        this.contentFull = contentFull;
    }

    public void setMoment(Date moment) {
        this.moment = moment;
    }

    public void setIdAuthor(int idAuthor) {
        this.idAuthor = idAuthor;
    }

    public void setAvatar(String avatar) {
        this.avatar = avatar;
    }

    
    public int getId() {
        return id;
    }

    public String getTitle() {
        return title;
    }

    public String getContentShort() {
        return contentShort;
    }

    public String getContentFull() {
        return contentFull;
    }

    public Date getMoment() {
        return moment;
    }

    public int getIdAuthor() {
        return idAuthor;
    }

    public String getAvatar() {
        return avatar;
    }

    
}
