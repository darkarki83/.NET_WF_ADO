package com.artk.autocomplite;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.os.Handler;
import android.view.KeyEvent;
import android.view.View;
import android.widget.AdapterView;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import java.util.ArrayList;


/*  AutoCompleteTextView
public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        AutoCompleteTextView auto = findViewById(R.id.autoComplite);

        String[] words = getResources().getStringArray(R.array.array1);

        ArrayAdapter<String> adapter = new ArrayAdapter<>(this,
                android.R.layout.simple_list_item_1, words);

        auto.setAdapter(adapter);
    }

}*/

/*  List View
public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        ListView list = findViewById(R.id.list);

        String[] words = getResources().getStringArray(R.array.array1);

        ArrayAdapter<String> adapter = new ArrayAdapter<>(this,
                R.layout.item , words);

        list.setAdapter(adapter);
    }

}
*/


import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.widget.ArrayAdapter;
import android.widget.AutoCompleteTextView;
import android.widget.ListView;

/*  AutoCompleteTextView
public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        AutoCompleteTextView auto = findViewById(R.id.autoComplite);

        String[] words = getResources().getStringArray(R.array.array1);

        ArrayAdapter<String> adapter = new ArrayAdapter<>(this,
                android.R.layout.simple_list_item_1, words);

        auto.setAdapter(adapter);
    }

}*/

/*  List View
public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        ListView list = findViewById(R.id.list);

        String[] words = getResources().getStringArray(R.array.array1);

        ArrayAdapter<String> adapter = new ArrayAdapter<>(this,
                R.layout.item , words);

        list.setAdapter(adapter);
    }

}
*/
/*  List View  С кнопкой добавления  */

public class MainActivity extends AppCompatActivity {

    EditText edit;
    ListView list;

    ArrayList<String> info;
    ArrayAdapter<String> adapter;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        edit = findViewById(R.id.edit1);
        list = findViewById(R.id.list1);

        info = new ArrayList<>();

        adapter = new ArrayAdapter<>(this, android.R.layout.simple_list_item_1, info);
        list.setAdapter(adapter);

        edit.setOnKeyListener(new View.OnKeyListener() {
            public boolean onKey(View v, int keyCode, KeyEvent event) {
                if (event.getAction() == KeyEvent.ACTION_DOWN)
                    if (keyCode == KeyEvent.KEYCODE_ENTER) {
                        add(null);
                        return true;
                    }
                return false;
            }
        });

        list.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            public void onItemClick(AdapterView<?> parent, View v, int position, long id) {
                Toast.makeText(getApplicationContext(), ((TextView) v).getText(), Toast.LENGTH_SHORT).show();
            }
        });
    }

    public void add(View v) {
        boolean flag = false;

        for (int i = 0; i < info.size(); i++){
            if(info.get(i).toString().equals(edit.getText().toString())){
                Toast.makeText(getApplicationContext(), "Есть такое слово", Toast.LENGTH_SHORT).show();
                flag = true;
            }
        }
        if(!flag) {
            info.add(0, edit.getText().toString());
            adapter.notifyDataSetChanged();   // Предуприждаю что в колекции чтото поменялось
            // reread array
        }
        edit.setText("");

      new Handler().postDelayed(new Runnable() {
            @Override
            public void run() {
                edit.requestFocus();  //вернуть фокус
            }
        }, 150);
    }
}
