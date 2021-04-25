package util;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;

/**
 *
 * @author artem
 */
public class UserUtil {

    public static ArrayList<orm.User> getListUser() {
        
        ArrayList<orm.User> users = new ArrayList<>();

        try {
            ResultSet res = util.Db.getConnection()
                    .createStatement()
                    .executeQuery("SELECT * FROM Users");

            while (res.next()) {
                users.add(new orm.User(res.getInt("id"),
                        res.getString("name"),
                        res.getString("email"),
                        res.getString("avatar"),
                        res.getDate("moment_create"),
                        res.getDate("moment_last_visit"),
                        res.getInt("id_role")
                ));
            }
        } catch (InstantiationException | SQLException ex) {
            System.out.println("UserUtil 1 " + ex.getMessage());
            return null;
        }
        return users;
    }

    public static boolean updateById(String uid, String role) {
        try {
            Db.getConnection()
                    .createStatement()
                    .executeUpdate(
                            String.format(
                                    "UPDATE Users SET id_role=%s WHERE id=%s",
                                    role,
                                    uid
                            )
                    );
        } catch (InstantiationException | SQLException ex) {
            System.out.println("UserUtil 2 " + ex.getMessage());
            return false;
        }
        return true;
    }

    public static boolean deleteById(String uid) {

        try {
            util.Db.getConnection()
                    .createStatement()
                    .executeUpdate("DELETE FROM Users WHERE id=" + uid);
        } catch (InstantiationException | SQLException ex) {
            System.out.println("UserUtil 3 " + ex.getMessage());
            return false;
        }
        return true;
    }

    public static orm.User getById(int uid) {

        try {
            ResultSet res
                    = util.Db
                            .getConnection()
                            .createStatement()
                            .executeQuery("SELECT * FROM Users WHERE id=" + uid);

            if (res.next()) {
                return new orm.User(res.getInt("id"),
                        res.getString("name"),
                        res.getString("email"),
                        res.getString("avatar"),
                        res.getDate("moment_create"),
                        res.getDate("moment_last_visit"),
                        res.getInt("id_role"),
                        res.getString("pass_salt")
                );
            }
            //System.out.println(req.getAttribute("username"));
        } catch (InstantiationException | SQLException ex) {
            System.out.println("UserUtil 4 " + ex.getMessage());
            return null;
        }
        return null;
    }

    public static orm.User getById(String uid) {
        try {
            return UserUtil.getById(Integer.parseInt(uid));
        } catch (Exception ex) {
            System.out.println("UserUtil 5 " + ex.getMessage());
        }
        return null;
    }
    
     public static boolean update(String str) {
        try {
            Db.getConnection()
                    .createStatement()
                    .executeUpdate(str);
        } catch (InstantiationException | SQLException ex) {
            System.out.println("User update fail" + ex.getMessage());
            return false;
        }
        return true;
    }

}
