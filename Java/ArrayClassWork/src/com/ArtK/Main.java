package com.ArtK;

import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
	// write your code here

        Scanner scan = new Scanner(System.in);

        System.out.println("Write column in array :");
        int first = scan.nextInt();
        System.out.println("Write rows in array :");
        int second = scan.nextInt();

        int [][] ourArray = new int[first][second];
        int in = 1;

        for (int i = 0; i < ourArray.length; i++) {
            for (int j = 0; j < ourArray[i].length; j++) {
                if(i % 2 == 0)
                    ourArray[i][j] = in;
                else
                    ourArray[i][ourArray[i].length - 1 - j] = in;
                in++;
            }
        }
        for (int i = 0; i < ourArray.length; i++) {
            for (int j = 0; j < ourArray[i].length; j++) {
                System.out.print("arr[" + i + "][" + j + "] = " + ourArray[i][j] + "  ");
            }
            System.out.println();
        }
    }
}
