package com.artk.mylist;


import android.os.Bundle;
import android.view.View;
import android.widget.ListView;
import android.widget.SimpleAdapter;
import android.widget.TextView;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

public class MainActivity extends AppCompatActivity {
    
    ArrayList<HashMap<String, Object>> all;
    
    String[] names = {"Монитор", "Мышка", "Клавиатера"};
    boolean[] checked = {false, false, false};
    String[] price = {"4500", "1500", "2000"};
    String[] money = {"", "€", "$"};
    int pic = R.drawable.enot;
    int[] to = {R.id.img1, R.id.t1, R.id.cb1, R.id.price};

    String[] from = {"photo", "name", "check", "price"};

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        ListView people = findViewById(R.id.list);

        all = new ArrayList<>(names.length);
        HashMap<String, Object> map;

        for (int i = 0; i < names.length; i++) {
            map = new HashMap<>();
            map.put(from[0], pic);
            map.put(from[1], names[i]);
            map.put(from[2], checked[i]);
            map.put(from[3], price[i]);
            all.add(map);
        }

        SimpleAdapter adapter = new SimpleAdapter(this, all, R.layout.my_item, from, to);

        people.setAdapter(adapter);
    }

    public void Dollar(View view) {

        ListView list = findViewById(R.id.list);

        for (int i = 0; i < names.length; i++) {

            HashMap<String, Object> map = all.get(i);
            map.remove(from[3]);
            map.put(from[3], (int)Double.parseDouble(price[i]) / 28);
        }

        SimpleAdapter adapter = new SimpleAdapter(this, all, R.layout.my_item, from, to);
        list.setAdapter(adapter);
    }

    public void Euro(View view) {
        ListView list = findViewById(R.id.list);

        for (int i = 0; i < names.length; i++) {

            HashMap<String, Object> map = all.get(i);
            map.remove(from[3]);
            map.put(from[3], (int)Double.parseDouble(price[i]) / 33);
        }

        SimpleAdapter adapter = new SimpleAdapter(this, all, R.layout.my_item, from, to);
        list.setAdapter(adapter);
    }

    public void Grv(View view) {

        ListView list = findViewById(R.id.list);

        for (int i = 0; i < names.length; i++) {

            HashMap<String, Object> map = all.get(i);
            map.remove(from[3]);
            map.put(from[3], price[i]);
        }

        SimpleAdapter adapter = new SimpleAdapter(this, all, R.layout.my_item, from, to);
        list.setAdapter(adapter);
    }
}




/*
import android.os.Bundle;
import android.widget.ListView;
import android.widget.SimpleAdapter;

import androidx.appcompat.app.AppCompatActivity;

import java.util.ArrayList;
import java.util.HashMap;

public class MainActivity extends AppCompatActivity {

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        ListView people = findViewById(R.id.list);

        String[] names = {"Александр Сашин", "Игорь Игорев", "Владислав Владиславенко"};

        boolean[] checked = {false, true, true};

        int pic = R.drawable.enot;

        ArrayList<HashMap<String, Object>> al = new ArrayList<>(names.length);
        HashMap<String, Object> map;

        String[] from = {"photo", "name", "check"};
        int[] to = {R.id.img1, R.id.t1, R.id.cb1};

        for (int i = 0; i < names.length; i++) {
            map = new HashMap<>();
            map.put(from[0], pic);
            map.put(from[1], names[i]);
            map.put(from[2], checked[i]);
            al.add(map);
        }

        SimpleAdapter adapter = new SimpleAdapter(this, al, R.layout.my_item, from, to);

        people.setAdapter(adapter);
    }
}*/