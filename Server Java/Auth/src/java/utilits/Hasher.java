package utilits;

import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;
import javax.xml.bind.DatatypeConverter;

/**
 *
 * @author artem
 */
public class Hasher {
    public static String md5(String txt) {
        
        try {
            return DatatypeConverter.printHexBinary(
                MessageDigest
                    .getInstance("MD5")
                    .digest(txt.getBytes())
            );
        }
        catch(NoSuchAlgorithmException ex) {
            return null;
        }
        
     
    }    
}
