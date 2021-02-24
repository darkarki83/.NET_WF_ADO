package com.artk.handler;

import android.os.Handler;
import android.os.Bundle;
import android.util.Log;
import android.view.View;

import androidx.appcompat.app.AppCompatActivity;

import java.text.SimpleDateFormat;

public class MainActivity extends AppCompatActivity {

    Handler h = new Handler();
    String INFO = "INFO_";
    long startTime = System.currentTimeMillis();

    @Override
    protected void onSaveInstanceState(Bundle outState) {
        super.onSaveInstanceState(outState);
        outState.putLong("start", startTime);
        Log.i(INFO, "onSaveState");
    }

    @Override
    protected void onRestoreInstanceState(Bundle savedState) {
        super.onRestoreInstanceState(savedState);
        startTime = savedState.getLong("start");
        Log.i(INFO, "onRestoreState");
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        runTimer();
    }

    public void runTimer() {

        h.post(new Runnable() {
            @Override
            public void run() {
                long date = System.currentTimeMillis() - startTime;
                SimpleDateFormat sdf = new SimpleDateFormat("HH:mm:ss.SSS");
                String dateString = sdf.format(date);
                getSupportActionBar().setTitle(dateString);
                h.postDelayed(this, 1);
            }
        });
    }
}
