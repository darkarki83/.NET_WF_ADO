package model;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.util.ArrayList;

/**
 *
 * @author artem
 */
public class Db {

    // connector
    private Connection connection;

    public Connection getConnection() throws ClassNotFoundException, SQLException {
        // 3.1. Подключение класса
        // ~ Не требуется для Java > 8

        if (connection == null) {

            /*Class.forName("com.mysql.cj.jdbc.Driver");

            String connectionString
                    = "jdbc:mysql://localhost:3306/java_hello" // Размещение БД
                    + "?useUnicode=true&characterEncoding=UTF-8" // Кодировка канала (подключения)
                    + "&useJDBCCompliantTimezoneShift=true&useLegacyDatetimeCode=false&serverTimezone=UTC";
            // При проблемах согласования времени
            connection = DriverManager.getConnection(
                    connectionString,
                    "hello_user",
                    "artem"
            );*/
            Class.forName("com.mysql.cj.jdbc.Driver");

            // 3.2. Подключение к СУБД
            String connectionString
                    = "jdbc:mysql://localhost:3306/java_hello" // Размещение БД
                    + "?useUnicode=true&characterEncoding=UTF-8" // Кодировка канала (подключения)
                    + "&useJDBCCompliantTimezoneShift=true&useLegacyDatetimeCode=false&serverTimezone=UTC";
            // При проблемах согласования времени

            try {
                connection = DriverManager.getConnection(
                        connectionString,
                        "hello_user",
                        "artem"
                );

            } catch (SQLException ex) {
                System.out.println(ex.getMessage());
                return null;
            }
        }

        return connection;
    }


    





}
