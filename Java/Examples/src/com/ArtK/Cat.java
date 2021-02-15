package com.ArtK;
 /** Cat class Example*/
public class Cat implements Comparable<Cat> {
    static int count;

    String nick;
    int age;
    String color;

    static {    // static section
        count = 0;
    }

     {                 // экземплярная секция (Login, File work, some thick else or... )
         System.out.println("экземплярная секция");
     }

     public Cat() throws Exception {
        this("Muka", 2, "blue");
     }

    public Cat(String nick, int age, String color) throws Exception {

        /*if(count >= 1) {
            throw new Exception("To many Cats");
        }
        else*/
            count++;

        this.nick = nick;
        this.age = age;
        this.color = color;
    }

    public void setNick(String nick) {
        this.nick = nick;
    }
    public String getNick() {
        return nick;
    }

    public void setAge(int age) {
        this.age = age;
    }
    public int getAge() {
        return age;
    }

    public void setColor(String color) {
        this.color = color;
    }
    public String getColor() {
        return color;
    }

    @Override
    public String toString() {
        return "Cat{" +
                "nick='" + nick + '\'' +
                ", age=" + age +
                ", color='" + color + '\'' +
                '}';
    }

     @Override
     public int compareTo(Cat o) {

        return compareToInt( o );   // CompareTo Age

         //return this.getNick().compareTo( o.getNick());  // CompareToNick

     }

     public int compareToInt(Cat o){
         if (this.age > (o.age) )
             return -1;
         else if (this.age < (o.age))
             return 1;
         else return 0;
     }

 }
