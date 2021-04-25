/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package util;

import java.sql.ResultSet;
import java.util.ArrayList;

/**
 *
 * @author artem
 */
public class RegUtil {

    public static boolean addUser(String username, String hash, String salt, String useremail, String avatarFull) {
        try {
            util.Db.getConnection()
                    .createStatement()
                    .executeUpdate(
                            String.format(
                                    "INSERT INTO Users(name,pass_hash,pass_salt,email,id_role,avatar)"
                                    + " VALUES("
                                    + " '%s','%s', '%s', '%s', %d, %s)",
                                    username,
                                    hash,
                                    salt,
                                    useremail,
                                    3,
                                    avatarFull
                            ));
        } catch (Exception ex) {
            System.out.println("RegUtil 1 " + ex.getMessage());
            return false;
        }
        return true;
    }

    public static int haveUser(String username) {

        int n = -1;

        try {
            ResultSet res
                    = util.Db.getConnection()
                            .createStatement()
                            .executeQuery("SELECT COUNT(*) FROM Users WHERE name LIKE '" + username + "' ");
            res.next();
            n = res.getInt(1);
        } catch (Exception ex) {
            System.out.println("RegUtil 2 " + ex.getMessage());
        }
        return n;
    }
}
