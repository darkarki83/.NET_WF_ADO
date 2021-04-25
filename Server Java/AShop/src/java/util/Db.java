package util;

import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.sql.Connection;
import java.sql.DriverManager;
import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;

/**
 *
 * @author artem
 */
public class Db {
    private static Connection connection;

    public static Connection getConnection() throws InstantiationException {

        File path = new File( "." ) ;
        //System.out.println(path.getAbsolutePath());
        // потом поигратся
        
        File ini = new File(path, "db2.ini");
        Map<String, String> iniDate = new HashMap<>();

        if ( !ini.canRead()) {
            throw new InstantiationException("File db.ini not readed");
        }

        try (FileReader reader = new FileReader(ini);
                Scanner scanner = new Scanner(reader)) {

            while (scanner.hasNext()) {
                String line = scanner.nextLine();
                String[] date = line.split("=");
                iniDate.put(date[0], date[1]);

            }
        } catch (IOException ex) {
            throw new InstantiationException("File db.ini not readed error " + ex.getMessage());
        }

        String host = iniDate.get("host");
        String port = iniDate.get("port");
        String name = iniDate.get("name");
        String user = iniDate.get("user");
        String pass = iniDate.get("pass");

        if (host == null || port == null || name == null || user == null
                || pass == null) {
            throw new InstantiationException("File db.ini containt not all date ");
        }

        String connectionString = String.format(
                "jdbc:mysql://%s:%s/%s?useUnicode=true&characterEncoding=UTF-8&useJDBCCompliantTimezoneShift=true&useLegacyDatetimeCode=false&serverTimezone=UTC"  // При проблемах согласования времени        
        , host, port, name
        );
        
        try {
            Class.forName("com.mysql.cj.jdbc.Driver");
            connection = DriverManager.getConnection(
                connectionString,
                user,
                pass
            );
        }
        catch (Exception ex) {
            throw new InstantiationException("Db conetion error " + ex.getMessage());
        }
        
        return connection;
    }
}
