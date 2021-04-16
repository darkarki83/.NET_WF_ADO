package orm;

import java.sql.Date;

/**
 *
 * @author artem
 */
public class User {
    
    int id;
    String name;
    String nik;
    String email;
    String avatar;
    Date regMoment;
    Date authMoment;
    int roleFk;
    String salt;



    public User(int id, String name, String nik, String email, String avatar, Date regMoment, Date authMoment, int roleFk, String salt) {
        this.id = id;
        this.name = name;
        this.nik = nik;
        this.email = email;
        this.avatar = avatar;
        this.regMoment = regMoment;
        this.authMoment = authMoment;
        this.roleFk = roleFk;
        this.salt = salt;
    }

    public User(int id, String name, String nik, String email, String avatar, Date regMoment, Date authMoment, int roleFk) {
        this.id = id;
        this.name = name;
        this.nik = nik;
        this.email = email;
        this.avatar = avatar;
        this.regMoment = regMoment;
        this.authMoment = authMoment;
        this.roleFk = roleFk;
    }
    
    public User() {
        
    }

    public void setId(int id) {
        this.id = id;
    }

    public void setName(String name) {
        this.name = name;
    }

    public void setNik(String nik) {
        this.nik = nik;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public void setAvatar(String avatar) {
        this.avatar = avatar;
    }

    public void setRegMoment(Date regMoment) {
        this.regMoment = regMoment;
    }

    public void setAuthMoment(Date authMoment) {
        this.authMoment = authMoment;
    }

    public void setRoleFk(int roleFk) {
        this.roleFk = roleFk;
    }

    public void setSalt(String salt) {
        this.salt = salt;
    }
    
    public int getId() {
        return id;
    }

    public String getName() {
        return name;
    }

    public String getNik() {
        return nik;
    }

    public String getEmail() {
        return email;
    }

    public String getAvatar() {
        return avatar;
    }

    public Date getRegMoment() {
        return regMoment;
    }

    public Date getAuthMoment() {
        return authMoment;
    }

    public int getRoleFk() {
        return roleFk;
    }
  
    public String getSalt() {
        return salt;
    }
}
