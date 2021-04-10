package utilits;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;

/**
 *
 * @author artem
 */
public class RoleUtil {

    private static ArrayList<orm.Role> roles;

    public static ArrayList<orm.Role> getList() {

        if (roles == null) {
            roles = new ArrayList<>();

            try {
                ResultSet res = Db.getConnection()
                        .createStatement()
                        .executeQuery("SELECT * FROM Roles");

                while (res.next()) {
                    roles.add(new orm.Role(
                            res.getInt("id"),
                            res.getString("title"),
                            res.getShort("can_read"),
                            res.getShort("can_write"),
                            res.getShort("can_delete")
                    ));
                }
            } catch (InstantiationException | SQLException ex) {
                System.out.println(ex.getMessage());
                return null;
            }
        }
        return roles;
    }
    
    public static orm.Role GetById( int roleId ) {
        
        for(orm.Role role : roles) {
            if(role.getId() == roleId) {
                return role;
            }
        }
        return null;
    }
    
    public static orm.Role GetByUser( orm.User user ) {
        return GetById(user.getRoleFk());
    }
}
