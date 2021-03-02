package com.artk.part4;

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
}