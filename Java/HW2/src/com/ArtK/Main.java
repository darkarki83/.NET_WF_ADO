package com.ArtK;

import java.math.BigInteger;
import java.util.Calendar;
import java.util.GregorianCalendar;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) throws InterruptedException {
	// write your code here

        /*BigInteger num = new BigInteger("102252222222222222222222222455");
        System.out.println(num);
        BigInteger second = new BigInteger("11111111111111111111102455");
        System.out.println(num.add(second));*/
        // big int


        /*System.out.println("1");
        Thread.sleep(1000);
        System.out.println("2");
        Thread.sleep(2000);
        System.out.println("3");

        Scanner scan = new Scanner(System.in);
        System.out.println("Please, enter some number");
        double val = scan.nextDouble();

        System.out.println("Please, Your name");
        String str = scan.next();

        System.out.println(val);
        System.out.println(str);*/

        /*var date = new GregorianCalendar();
        System.out.println(date.get(Calendar.DATE));
        System.out.println(date.get(Calendar.HOUR));
        System.out.println(date.getTime());
        System.out.println(date.get(Calendar.YEAR));*/

        Scanner scan = new Scanner(System.in);
        System.out.println("Please, enter X");
        int my_x = scan.nextInt() * 2;

        System.out.println("Please, enter Y");
        int my_y = scan.nextInt();

        for (int y = 1; y < my_y * 2; y++) {
            for (int x = 1; x < my_x * 2; x++) {

                if(y == 1 && (x >= my_x / 2 && x <= my_x * 1.5))
                    System.out.print("*");
                else  if(y == my_y && (x >= my_x / 2 && x <= my_x * 1.5))
                    System.out.print("*");
                else  if(x == (int)(my_x / 2) && (y > 0 && y < my_y))
                    System.out.print("*");
                else  if(x == (my_x * 1.5) && (y > 1 && y < my_y))
                    System.out.print("*");

                else if(y == my_y / 2 && (x >= 1 && x < my_x))
                    System.out.print("*");
                else if(y == my_y * 1.5 && (x >= 1 && x <= my_x))
                    System.out.print("*");
                else  if(x == 1 && (y >= my_y / 2 && y < my_y * 1.5))
                    System.out.print("*");
                else  if(x == my_x && (y >= my_y / 2 && y < my_y * 1.5))
                    System.out.print("*");

                else if(y == (int)(((x - my_x * 1.5) * (0.5 * my_y - 1)) / ( - my_x * 0.5) + 1) && y < my_y * 0.5 )
                    System.out.print("*");
                else if(y == (int)( ((x - my_x * 0.5) * (0.5 * my_y - 1)) / (1 - my_x / 2) + 1) && y > 1 )
                        System.out.print("*");
                else if(y == (int)( ((x - my_x / 2) * (0.5 * my_y)) / (1 - my_x / 2) + my_y) && y >my_y)
                        System.out.print("*");
                else if(y == (int)( ((x - 1.5 * my_x) * (0.5 * my_y)) / (-0.5 * my_x) + my_y) && y > my_y && y < my_y * 1.5)
                        System.out.print("*");
                else
                    System.out.print(" ");
            }
            System.out.println();
        }
    }
}
