package com.ArtK;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.List;

class Monster {
    String name;
    int health;
    int ammo;
    public Monster(int health, int ammo, String name) {
        this.health = health;
        this.ammo = ammo;
        this.name = name;
    }
    public void about() {
        System.out.println("Monster " + name + " with health = " + health + " and ammo =  " + ammo);
    }
}
class SortByHealth implements Comparator<Monster> {
    @Override
    public int compare(Monster m1, Monster m2) {
        if (m1.health > m2.health) {
            return -1;
        }
        if (m1.health < m2.health) {
            return 1;
        }
        return 0;
    }
}

class SortByName implements Comparator<Monster> {

    @Override
    public int compare(Monster o1, Monster o2) {
        return o1.name.compareTo(o2.name);
    }
}
class Main {
    public static void main(String[] args) {
        Monster m1 = new Monster(70, 20, "Mike Wazowski");
        Monster m2 = new Monster(90, 20, "Sullivan");
        Monster m3 = new Monster(80, 20, "Johnny Worthington");
        List<Monster> list = new ArrayList<>();
        list.add(m1);
        list.add(m2);
        list.add(m3);
        Collections.sort(list, new SortByName());
        for (Monster m : list) {
            m.about();
        }
    }
}