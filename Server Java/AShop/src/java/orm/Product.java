package orm;

import java.sql.Date;

/**
 *
 * @author artem
 */
public class Product {

    private int id;
    private int userId;
    private String title;
    private String summary;
    private String contentFull;
    private float price;
    private float discount;
    private int quentity;
    private Date createAt;
    private Date updateAt;
    private String avatar;
    private int blocked;
    String blockedReason;

    public Product() {
    }

    public Product(int id, int userId, String title, String summary, String contentFull, float price, float discount, int quentity, Date createAt, Date updateAt, String avatar) {
        this.id = id;
        this.userId = userId;
        this.title = title;
        this.summary = summary;
        this.contentFull = contentFull;
        this.price = price;
        this.discount = discount;
        this.quentity = quentity;
        this.createAt = createAt;
        this.updateAt = updateAt;
        this.avatar = avatar;
    }

    public Product(int id, int userId, String title, String summary, String contentFull, float price, float discount, int quentity, Date createAt, Date updateAt, String avatar, int blocked, String blockedReason) {
        this.id = id;
        this.userId = userId;
        this.title = title;
        this.summary = summary;
        this.contentFull = contentFull;
        this.price = price;
        this.discount = discount;
        this.quentity = quentity;
        this.createAt = createAt;
        this.updateAt = updateAt;
        this.avatar = avatar;
        this.blocked = blocked;
        this.blockedReason = blockedReason;
    }

    public String getBlockedReason() {
        return blockedReason;
    }

    public void setBlockedReason(String blockedReason) {
        this.blockedReason = blockedReason;
    }
    
    public void setId(int id) {
        this.id = id;
    }

    public void setUserId(int userId) {
        this.userId = userId;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public void setSummary(String summary) {
        this.summary = summary;
    }

    public void setContentFull(String contentFull) {
        this.contentFull = contentFull;
    }

    public void setPrice(float price) {
        this.price = price;
    }

    public void setDiscount(float discount) {
        this.discount = discount;
    }

    public void setQuentity(int quentity) {
        this.quentity = quentity;
    }

    public void setCreateAt(Date createAt) {
        this.createAt = createAt;
    }

    public void setUpdateAt(Date updateAt) {
        this.updateAt = updateAt;
    }

    public void setAvatar(String avatar) {
        this.avatar = avatar;
    }

    public void setBlocked(int blocked) {
        this.blocked = blocked;
    }
    
    public int getId() {
        return id;
    }

    public int getUserId() {
        return userId;
    }

    public String getTitle() {
        return title;
    }

    public String getSummary() {
        return summary;
    }

    public String getContentFull() {
        return contentFull;
    }

    public float getPrice() {
        return price;
    }

    public float getDiscount() {
        return discount;
    }

    public int getQuentity() {
        return quentity;
    }

    public Date getCreateAt() {
        return createAt;
    }

    public Date getUpdateAt() {
        return updateAt;
    }

    public String getAvatar() {
        return avatar;
    }

    public int getBlocked() {
        return blocked;
    }
    
}
