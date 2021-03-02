package com.artk.filedialog;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }

    public void fun(View view) {
        artemDialog d = new artemDialog();
        d.show(getSupportFragmentManager(), "dialog");
    }
}