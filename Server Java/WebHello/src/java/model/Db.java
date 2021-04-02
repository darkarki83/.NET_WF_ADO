package model;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;

public class Db {
    private Connection connection ;
    
    public Connection getConnection() throws ClassNotFoundException, SQLException {
        if( connection == null ) {
            Class.forName( "com.mysql.cj.jdbc.Driver" ) ;
            String connectionString = 
                "jdbc:mysql://localhost:3306/java_hello"      // Размещение БД
                + "?useUnicode=true&characterEncoding=UTF-8"  // Кодировка канала (подключения)
                + "&useJDBCCompliantTimezoneShift=true&useLegacyDatetimeCode=false&serverTimezone=UTC" ;  // При проблемах согласования времени        
            connection = DriverManager.getConnection(
                    connectionString,
                    "hello_user",
                    "artem"
            ) ;
        }
        return connection ;
    }
    // ORM - Object Relation Mapping
    public ArrayList<model.orm.User> getUsersList() {
        ArrayList<model.orm.User> res = new ArrayList<>() ;
        if( connection == null )
            try{ getConnection() ; }
            catch( Exception ignored ) { return null ; }
        try {
            ResultSet rs = 
                    connection
                    .createStatement()
                    .executeQuery( "SELECT  id, name FROM Users" ) ;
            while( rs.next() ) {
                res.add(
                    new model.orm.User(
                        rs.getInt( "id" ) ,
                        rs.getString( "name" )
                    )
                ) ;
            }
        } catch( SQLException ex ) {
            System.out.println( ex.getMessage() ) ;
            return null ;
        }
        return res ;
    }
    
    public boolean deleteUser(int uid){
        
           if( connection == null )
            try{ getConnection() ; }
            catch( Exception ignored ) { return false ; }
           
           try {
                    connection
                    .createStatement()
                    .executeUpdate("DELETE FROM Users WHERE id=" + uid);
        } catch( SQLException ex ) {
            System.out.println( ex.getMessage() ) ;
            return false ;
        }  
        return true;
    } 
    
    public boolean addUser(model.orm.User newUser){

        if( connection == null )
            try{ getConnection() ; }
            catch( Exception ignored ) { return false ; }
        
           try {
               Statement st =  connection.createStatement();
               ResultSet res = st.executeQuery("SELECT MAX(id) FROM Users");
               res.next();
               
               st.executeUpdate(
                       String.format(
                               "INSERT INTO Users VALUES('%d', '%s')",
                               res.getInt(1) + 1,
                               newUser.getName()
                       ));
        } catch( SQLException ex ) {
            System.out.println( ex.getMessage() ) ;
            return false ;
        }  
        return true;
    }
    
    public boolean editUser(model.orm.User editUser) {
        if( connection == null )
            try{ getConnection() ; }
            catch( Exception ignored ) { return false ; }
        
           try {
               connection
                    .createStatement()
                    .executeUpdate(
                        String.format(
                               "UPDATE Users SET name = '%s' WHERE id = %d",
                               editUser.getName(),
                               editUser.getId()
                                
                       ));
        } catch( SQLException ex ) {
            System.out.println( ex.getMessage() ) ;
            return false ;
        }
        return true;
    }

    

}

