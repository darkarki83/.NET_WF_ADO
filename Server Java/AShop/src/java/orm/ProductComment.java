package orm;

import java.sql.Date;

/**
 *
 * @author artem
 */
public class ProductComment {
    
    private int id;
    private int idProduct;
    private int idAuthor;
    private int idRef;
    private Date moment;
    private String commint;
    private String authorNik;
    private int blocked;

    public ProductComment() {
    }

    public ProductComment(int id, int idAuthor, int idProduct, int idRef, Date moment, String commint, String authorNik, int blocked) {
        this.id = id;
        this.idAuthor = idAuthor;
        this.idProduct = idProduct;
        this.idRef = idRef;
        this.moment = moment;
        this.commint = commint;
        this.authorNik = authorNik;
        this.blocked = blocked;
    }
    
     public ProductComment(int id, int idAuthor, int idProduct, int idRef, Date moment, String commint, int blocked) {
        this.id = id;
        this.idAuthor = idAuthor;
        this.idProduct = idProduct;
        this.idRef = idRef;
        this.moment = moment;
        this.commint = commint;
        this.blocked = blocked;
    }
    
    public void setId(int id) {
        this.id = id;
    }

    public void setIdAuthor(int idAuthor) {
        this.idAuthor = idAuthor;
    }

    public void setIdProduct(int idProduct) {
        this.idProduct = idProduct;
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

    public void setAuthorNik(String authorNik) {
        this.authorNik = authorNik;
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

    public int getIdProduct() {
        return idProduct;
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


