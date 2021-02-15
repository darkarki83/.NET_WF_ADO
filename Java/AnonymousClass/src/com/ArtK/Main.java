package com.ArtK;

//# region 1

/*class Button {
    void setOnClickListener(OnClickListener listener) {
        listener.onClick();
    }
}
// стандартный интерфейс андроида
interface OnClickListener {
    void onClick();
}*/

//# endregion

import java.awt.*;

//# region 2
/*
class Button {
    void setOnClickListener(Animal a){
        a.sleep();
    }
}

abstract class Animal {
    abstract void sleep();
}

//# endregion 2
 */

//# region 3
class Button {
    void setOnClickListener(OnClickListener listener) {
        listener.onClick(null, 10, 20);
    }
}

interface  OnClickListener {
    void onClick(Button b, int x, int y);
}
//# endregion 3



public class Main {
    public static void main(String[] args) {

        //# region 2
        /*
        Button b = new Button();

        b.setOnClickListener(new Animal() {
            @Override
            void sleep() {
                System.out.println("May May");
            }
        });*/
        //# endregion 2


        //# region 1
        /*Button b = new Button();

        /*
        b.setOnClickListener(() -> {  // string lambda
            System.out.println("Lambda");
        });

        b.setOnClickListener(() -> {   // block lambda
            System.out.println("One");
            System.out.println("Two");
        });*/
        //# endregion

        //# region 3

        Button b = new Button();

        b.setOnClickListener(new OnClickListener() { //полный вариант
            @Override
            public void onClick(Button b, int x, int y) {
                System.out.println(x + " " + y);
            }
        });

        // вариант лямда выражения
        b.setOnClickListener((b1, x, y) -> System.out.println(x + " " + y));

        //# endregion 3

    }
}

