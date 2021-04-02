
package files;

import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.util.Scanner;

/**
 *
 * @author artem
 */
public class FileDemo {
    
    public void Show() throws FileNotFoundException{
                                    // true -> дозапись
        /*try(FileWriter writer = new FileWriter("myTest.text" , true)){ 
            writer.write("\nprivet privet."); 
            writer.flush();
            System.out.println("Done");
        } catch(IOException ex ) {
            System.out.println(ex.getMessage());
        }
        
        try(FileReader reader = new FileReader("myTest.text")){
            
            int s;
            while( (s = reader.read()) != -1) {
                System.out.print((char)s);
                
            }
        } catch(IOException ex ) {
            System.out.println(ex.getMessage());
        }
        */
        
        try(FileReader reader = new FileReader("myTest.text")){
            Scanner scanner = new Scanner(reader);
            while(scanner.hasNext()) {
                
                System.out.println(scanner.nextLine()); 
            }
            
        } catch(IOException ex ) {
            System.out.println(ex.getMessage());
        }
        
        
        
        
        
        
    } 
}
