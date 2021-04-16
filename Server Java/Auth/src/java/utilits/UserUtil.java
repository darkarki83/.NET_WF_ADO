package utilits;

import java.sql.ResultSet;
import java.sql.SQLException;

/**
 *
 * @author artem
 */
public class UserUtil {

    public static orm.User getById(int uid) {

        try {
            ResultSet res
                    = Db
                            .getConnection()
                            .createStatement()
                            .executeQuery("SELECT * FROM Users WHERE id=" + uid);

            if (res.next()) {
                return new orm.User(res.getInt("id"),
                        res.getString("name"),
                        res.getString("nik"),
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
            System.out.println( "userUtil getById :" + ex.getMessage());
            return null;
        }
        return null;
    }
    
    public static orm.User getById(String uid) {
        try {
            return UserUtil.getById(Integer.parseInt(uid));
        }
        catch (Exception ex) {
            System.out.println( "userUtil getById(str) :" + ex.getMessage());
        }
        return null;
    }

    public static boolean deleteById(String uid) {

        try {
            Db.getConnection()
                    .createStatement()
                    .executeUpdate("DELETE FROM Users WHERE id=" + uid);
        } catch (InstantiationException | SQLException ex) {
            System.out.println(ex.getMessage());
            return false;
        }
        return true;
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
            System.out.println("User updateById fail" + ex.getMessage());
            return false;
        }
        return true;
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
