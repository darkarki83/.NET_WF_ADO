
package hello;

import java.util.ArrayList;

public class Hello {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        //System.out.println("Hello, world");
        
        /*int[] array = new int[20];
        for (int i = 0; i < array.length; i++) {
            array[i] = i + 1;
        }
        
        for(int a : array){                   // foreach
            System.out.print(a + " ");
        }
        System.out.println();
        
        // Colection
        
        ArrayList array2 = new ArrayList();
        array2.add(1);
        array2.add("string");
        array2.add(1.4);
        array2.add(true);
        
        for(Object a : array2){
            System.out.println(a);
        }
        */
        
        ArrayList<String> array3 = new ArrayList<>();
        
        array3.add("string");
        array3.add(1 + "");
        
        //  преимущества и недостатки
        
        //  преимущества
        // 1) Легко выйти по брейку
        // 2) Менее затратный по ресурсом
        
        //  недостатки
        // 1) Понижаем обстракию
        for( String a : array3){
            System.out.println(a);
        }
        
        //  недостатки
        // 1) Тяхело выйти по брейку(Try/catch)
        // 2) Более затратный по ресурсо(call function)

        // преимущества
        // 1) Позволяет работать с более правельный при работе с большими даными
        // (Вазлагаем на мехонизм колекции обход колекции=> более оптимизировано)
        // 2) Выравниваем уровень обстракции
        // Можно разбить по Task(Thread or async/await)
        array3.forEach(
                a -> System.out.println(a));
        
        
        
    }
    
}
