
package Database;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.Scanner;

/**
 *
 * @author artem
 */
public class DBHW {
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
        
       /* String str = "CREATE TABLE Products (id INT PRIMARY KEY, name VARCHAR(32), price Double)";
        
        try {
            cmd.executeUpdate(str);
        } 
        catch (SQLException ex) {
            System.out.println(ex.getMessage());
        }
        
         String add = "INSERT INTO `Products`(id, name, price) VALUES (1,'bread', 12.50),(2,'milk', 20.02),(3,'coffee', 225),(4,'water', 10.11),(5,'chiken', 88.20),(6,'beef', 122.02); ";
        
        try {
            cmd.executeUpdate(add);   // для запросов без возврата
        } 
        catch (SQLException ex) {
            System.out.println(ex.getMessage());

        }*/
        
        String select = "select * from Products;";
        
        try {
             System.out.print("id" + "  ");
               System.out.println("name");
               System.out.println("price");
               
            ResultSet res = cmd.executeQuery(select);   // для запросов c возврата
            
            Scanner scan = new Scanner(System.in);   // Search realization
            System.out.println("enter an serch string :: ");
            String sub = scan.next();
            
            while(res.next()){
                if(res.getString("name").contains(sub)) {
                    
                    System.out.print(res.getInt(1) + "   ");
                    System.out.print(res.getString("name") + "   ");
                    System.out.println(res.getString("price"));
                }
            }
            res.close();
            
           res = cmd.executeQuery(select);   // для запросов c возврата
            
            while(res.next()){
               
                    System.out.print(res.getInt(1) + "   ");
                    System.out.print(res.getString("name") + "   ");
                    System.out.println(res.getString("price"));
                
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
