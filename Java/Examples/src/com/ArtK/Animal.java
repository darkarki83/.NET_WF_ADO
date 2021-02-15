package com.ArtK;

public class Animal implements Comparable<Animal> {
    private int lapki;
    private String color;


    public Animal() {
        this(4, "no name");
    }

    public Animal(int lapki, String color) {
        this.lapki = lapki;
        this.color = color;
    }

    public int getLapki() {
        return lapki;
    }
    public void setLapki(int lapki) {
        this.lapki = lapki;
    }

    public String getColor() {
        return color;
    }
    public void setColor(String color) {
        this.color = color;
    }

    @Override
    public String toString() {
        return "Animal{" +
                "lapki=" + lapki +
                ", color='" + color + '\'' +
                '}';
    }

    @Override
    public int compareTo(Animal o) {

        if(this.lapki > o.lapki)
            return -1;
        else if(this.lapki < o.lapki)
            return 1;
        else return 0;
    }
}
