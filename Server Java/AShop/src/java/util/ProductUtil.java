/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package util;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;

/**
 *
 * @author artem
 */
public class ProductUtil {

    public static ArrayList<orm.Product> products;

    public static ArrayList<orm.Product> getList() {

        products = new ArrayList<>();
        try {
            ResultSet res = Db.getConnection()
                    .createStatement()
                    .executeQuery("SELECT * FROM product");

            while (res.next()) {
                products.add(new orm.Product(
                        res.getInt("id"),
                        res.getInt("userId"),
                        res.getString("title"),
                        res.getString("summary"),
                        res.getString("content_full"),
                        res.getFloat("price"),
                        res.getFloat("discount"),
                        res.getInt("quantity"),
                        res.getDate("createdAt"),
                        res.getDate("updatedAt"),
                        res.getString("avatar"),
                        res.getInt("blocked"),
                        res.getString("blocked_reason")
                ));
            }
        } catch (InstantiationException | SQLException ex) {
            System.out.println("ProductUtil 1" + ex.getMessage());
            return null;
        }

        return products;
    }

    public static orm.Product getById(int pId) {

        try {
            ResultSet res = Db.getConnection()
                    .createStatement()
                    .executeQuery("SELECT * FROM product WHERE id=" + pId);

            if (res.next()) {
                return new orm.Product(
                        res.getInt("id"),
                        res.getInt("userId"),
                        res.getString("title"),
                        res.getString("summary"),
                        res.getString("content_full"),
                        res.getFloat("price"),
                        res.getFloat("discount"),
                        res.getInt("quantity"),
                        res.getDate("createdAt"),
                        res.getDate("updatedAt"),
                        res.getString("avatar")
                );
            }
        } catch (InstantiationException | SQLException ex) {
            System.out.println("ProductUtil 2 " + ex.getMessage());
        }
        return null;
    }

    public static ArrayList<orm.ProductComment> getCommentsList(int pId) {
        try {
            ResultSet res = Db.getConnection()
                    .createStatement()
                    .executeQuery(
                            "SELECT C.*, U.name FROM Product_comment C "
                            + "LEFT JOIN Users U ON U.id=C.id_author WHERE C.blocked IS NULL AND C.id_product="
                            + pId);

            ArrayList<orm.ProductComment> productComments = new ArrayList<>();

            while (res.next()) {
                productComments.add(new orm.ProductComment(
                        res.getInt("id"),
                        res.getInt("id_product"),
                        res.getInt("id_author"),
                        res.getInt("id_ref"),
                        res.getDate("moment"),
                        res.getString("comment"),
                        res.getString("name"),
                        res.getInt("blocked")
                ));
            }
            return productComments;
        } catch (InstantiationException | SQLException ex) {
            System.out.println("ProductUtil 3 " + ex.getMessage());
        }
        return null;
    }

    public static ArrayList<orm.ProductComment> getCommentsList() {
        try {
            ResultSet res = Db.getConnection()
                    .createStatement()
                    .executeQuery(
                            "SELECT C.*, U.name FROM Product_comment C "
                            + "LEFT JOIN Users U ON U.id=C.id_author");

            ArrayList<orm.ProductComment> productComment = new ArrayList<>();

            while (res.next()) {
                productComment.add(new orm.ProductComment(
                        res.getInt("id"),
                        res.getInt("id_product"),
                        res.getInt("id_author"),
                        res.getInt("id_ref"),
                        res.getDate("moment"),
                        res.getString("comment"),
                        res.getString("name"),
                        res.getInt("blocked")
                ));
            }
            return productComment;
        } catch (InstantiationException | SQLException ex) {
            System.out.println("ProductUtil 5 " + ex.getMessage());
        }
        return null;
    }

    public static ArrayList<orm.ProductComment> getCommentsList(orm.Product product) {
        ArrayList<orm.ProductComment> productCommints = util.ProductUtil.getCommentsList(product.getId());
        return productCommints;
    }

    public static boolean addComment(int idProduct, int idAuthor, String txt) {
        String query
                = "INSERT INTO Product_comment(id_product, id_author, comment)"
                + "VALUES( " + idProduct + ", " + idAuthor + ", '" + txt + "' )";
        try {
            Db.getConnection()
                    .createStatement()
                    .executeUpdate(query);
        } catch (InstantiationException | SQLException ex) {
            System.out.println("ProductUtil 4"
                    + ex.getMessage() + query);
            return false;
        }
        return true;
    }

    public static boolean disableComment(String idCommit) {

        String query
                = "UPDATE Product_comment SET blocked=if(blocked =1, null, 1) WHERE id =" + idCommit;
        try {
            Db.getConnection()
                    .createStatement()
                    .executeUpdate(query);
        } catch (InstantiationException | SQLException ex) {
            System.out.println(" ProductUtil 6"
                    + ex.getMessage() + query);
            return false;
        }
        return true;
    }

    public static ArrayList<orm.ProductComment> getCommentsUser(int uid) {

        try {
            ResultSet res = Db.getConnection()
                    .createStatement()
                    .executeQuery(
                            "SELECT * FROM Product_comment WHERE id_author=" + uid);

            ArrayList<orm.ProductComment> productComment = new ArrayList<>();

            while (res.next()) {
                productComment.add(new orm.ProductComment(
                        res.getInt("id"),
                        res.getInt("id_product"),
                        res.getInt("id_author"),
                        res.getInt("id_ref"),
                        res.getDate("moment"),
                        res.getString("comment"),
                        res.getInt("blocked")
                ));
            }
            return productComment;
        } catch (InstantiationException | SQLException ex) {
            System.out.println("ProductUtil 7 " + ex.getMessage());
        }
        return null;
    }

    public static boolean addProduct(orm.Product p) {

        String query
                = "INSERT INTO Product(userId, title, summary, content_full, price, discount, quantity, avatar)"
                + "VALUES( " + p.getUserId() + ", '" + p.getTitle().replace("'", "\\'") + "', '" + p.getSummary().replace("'", "\\'")
                + "', '" + p.getContentFull().replace("'", "\\'") + "', " + p.getPrice() + ",  " + p.getDiscount()
                + ", " + p.getQuentity() + ", " + p.getAvatar() + " )";

        try {
            Db.getConnection()
                    .createStatement()
                    .executeUpdate(query);
        } catch (InstantiationException | SQLException ex) {
            System.out.println("ProductUtil 8"
                    + ex.getMessage() + query);
            return false;
        }
        return true;
    }
    
     public static boolean disableProduct(String idCommit, String reason) {

        String query
                = "UPDATE Product SET blocked=if(blocked =1, null, 1), blocked_reason= '" + reason +  "' WHERE id =" + idCommit;
        try {
            Db.getConnection()
                    .createStatement()
                    .executeUpdate(query);
        } catch (InstantiationException | SQLException ex) {
            System.out.println(" ProductUtil 9"
                    + ex.getMessage() + query);
            return false;
        }
        return true;
    }
}
