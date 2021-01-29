package com.ArtK;

import java.util.Random;

public class Main {

    public static void main(String[] args) {
	// write your code here

        String pass = "";
        Random random = new Random();
        int myrand = 0;

        for (int i = 0; i < 10; i++)
        {
            switch (random.nextInt(3)) {
                case 0:
                    myrand = random.nextInt(10) + 48;
                    break;
                case 1:
                    myrand = random.nextInt(26) + 65;
                    break;
                case 2:
                    myrand = random.nextInt(26) + 97;
                    break;
            }
            pass = pass + (char)myrand;
            //System.out.printf(c + " ");
        }
        System.out.printf(pass);
    }
}
