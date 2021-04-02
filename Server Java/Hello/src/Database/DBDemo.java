package Database;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author artem
 */
public class DBDemo {

    public void Show() {
        // 3.1. Подключение класса
        // ~ Не требуется для Java > 8
        try {
            Class.forName("com.mysql.cj.jdbc.Driver");
        } catch (ClassNotFoundException ex) {
            System.out.println(ex.getMessage());
            return;
        }

        // 3.2. Подключение к СУБД
        String connectionString
                = "jdbc:mysql://localhost:3306/java_hello" // Размещение БД
                + "?useUnicode=true&characterEncoding=UTF-8" // Кодировка канала (подключения)
                + "&useJDBCCompliantTimezoneShift=true&useLegacyDatetimeCode=false&serverTimezone=UTC";
        // При проблемах согласования времени

        Connection con;      // объект-подключение

        try {
            con = DriverManager.getConnection(
                    connectionString,
                    "hello_user",
                    "artem"
            );

        } catch (SQLException ex) {
            System.out.println(ex.getMessage());
            return;
        }

        // 3.3. Выполнение команды
        Statement cmd;

        try {
            cmd = con.createStatement();
        } 
        catch (SQLException ex) {
            System.out.println(ex.getMessage());
            return;
        }
        
        String str = "CREATE TABLE users (id INT PRIMARY KEY, name VARCHAR(32))";
        
        try {
            cmd.executeUpdate(str);
        } 
        catch (SQLException ex) {
            System.out.println(ex.getMessage());
        }
        
        String add = "INSERT INTO `users`(id, name) VALUES (2,'nik'),(3,'artNik'); ";
        
        try {
            cmd.executeUpdate(add);   // для запросов без возврата
        } 
        catch (SQLException ex) {
            System.out.println(ex.getMessage());

        }
        
        String select = "select * from users;";
        
        try {
             System.out.print("id" + "  ");
               System.out.println("name");
               
            ResultSet res = cmd.executeQuery(select);   // для запросов c возврата
            
            while(res.next()){
                
               System.out.print(res.getString("id") + "   ");
               System.out.println(res.getString("name"));
            }
            
            res.close();
            
        } 
        catch (SQLException ex) {
            System.out.println(ex.getMessage());
            return;
        }
        
        try {
            con.close();
        }
        catch(SQLException ignore ){ }

        System.out.println("Done");
        
    }
}
