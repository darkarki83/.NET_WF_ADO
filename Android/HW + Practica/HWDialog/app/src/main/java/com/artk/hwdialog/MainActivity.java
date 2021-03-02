package com.artk.hwdialog;

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
        ArtemDialog d = new ArtemDialog("Enjoying", "");
        d.show(getSupportFragmentManager(), "dialog");

    }
}