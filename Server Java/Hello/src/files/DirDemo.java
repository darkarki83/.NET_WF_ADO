package files;

import java.io.File;

/**
 *
 * @author artem
 */

/*
    Работа с файловой системой.
    ч.1 директории и их содержимое
    задание - сделать аналог команды dir в cmd
 */
public class DirDemo {

    public void ShowDir() {
        // Основной класс для работы с файловой системой
        File file = new File("./"); // ./ - спец.имя текущая папка

        int dirCount = 0;
        int fileCount = 0;
        int totalSize = 0;

        /*
    // Только имена - файлы и папки
    for( String fname : file.list() ) {
        System.out.println( fname ) ;
    } */
        for (File f : file.listFiles()) {

            if (f.isDirectory()) {
                System.out.print("<DIR>\t");
                dirCount++;
            } else {
                System.out.print("    " + f.length() + " ");
                fileCount++;
                totalSize += f.length();
            }

            System.out.println(f.getName());

        }
        System.out.print("files " + fileCount + "\t");
        System.out.println(totalSize + " bites");
        System.out.println("dir " + dirCount);
        
        // Создание / удаление каталога
        // 1. Создание объекта (сам файл/каталог не создается)
        File subDir = new File("./subDir");

         // 2. Проверяем, есть ли
        if (subDir.isDirectory()) {
            // существует - delete dirictory
            try {
                subDir.delete();
                System.out.println("Delete");
            } catch (Exception ex) {
                System.out.println(ex.getMessage());
            }
        } else {
            // не существует - create dirictory
            try {
                subDir.mkdir();
                System.out.println("Created");
            } catch (Exception ex) {
                System.out.println(ex.getMessage());
            }
        }

    }

}
