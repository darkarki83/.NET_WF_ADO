package orm;

/**
 *
 * @author artem
 */
public class Role {
    int id;
    String title;
    short canRead;
    short canWrite;
    short canDelete;

    public Role(int id, String title, short canRead, short canWrite, short canDelete) {
        this.id = id;
        this.title = title;
        this.canRead = canRead;
        this.canWrite = canWrite;
        this.canDelete = canDelete;
    }

    public Role() {
    }

    public void setId(int id) {
        this.id = id;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public void setCanRead(short canRead) {
        this.canRead = canRead;
    }

    public void setCanWrite(short canWrite) {
        this.canWrite = canWrite;
    }

    public void setCanDelete(short canDelete) {
        this.canDelete = canDelete;
    }

    public int getId() {
        return id;
    }

    public String getTitle() {
        return title;
    }

    public short getCanRead() {
        return canRead;
    }

    public short getCanWrite() {
        return canWrite;
    }

    public short getCanDelete() {
        return canDelete;
    }
    
    
}
