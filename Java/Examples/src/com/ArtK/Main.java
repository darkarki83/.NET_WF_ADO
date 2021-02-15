package com.ArtK;

import java.io.*;
import java.util.*;
import java.text.*;
import java.math.*;
import java.util.regex.*;

public class Main {

    public static void main(String[] args) {


        Queue<Animal> animals = new PriorityQueue<Animal>();

        Animal first = new Animal(4, "mashka");
        Animal second = new Animal(2, "ptichka");
        Animal third = new Animal(3, "krisa");
        Animal four = new Animal(1, "netu");

        animals.add(first);
        animals.add(second);
        animals.add(third);
        animals.add(four);

        System.out.println(animals.remove());


    }//end of main
}//end of class
