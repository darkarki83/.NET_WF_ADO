package com.artk.cliker;

/*
* Задание №6:

Пользователю даётся 20 секунд, чтобы совершить максимально возможное количество кликов по кнопке.
По истечении времени показать тост, который сообщает набранное количество кликов, и максимальный рекорд по итогам всех попыток.

* */

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.os.Handler;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

import java.text.SimpleDateFormat;

public class MainActivity extends AppCompatActivity {

    private int clicks = 0;
    private  int bastScore = 0;
    private boolean games = false;

    Handler h = new Handler();
    TextView t;
    Button b;

    long startTime = System.currentTimeMillis() + 20000;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        b = findViewById(R.id.button);
        t = findViewById(R.id.textView);

        b.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if(games) {
                    clicks++;
                }else{
                    games = true;
                    b.setText("Click Me");
                    startTime = System.currentTimeMillis() + 20000;
                    clicks = 0;
                }
            }
        });

        runTimer();
    }

    @Override
    protected void onSaveInstanceState(@NonNull Bundle outState) {
        super.onSaveInstanceState(outState);

        outState.putInt("clicks", clicks);
        outState.putInt("bastScore", bastScore);
        outState.putLong("startTime", startTime);

    }

    @Override
    protected void onRestoreInstanceState(@NonNull Bundle savedInstanceState) {
        super.onRestoreInstanceState(savedInstanceState);

        savedInstanceState.getInt("clicks");
        savedInstanceState.getInt("bastScore");
        savedInstanceState.getLong("startTime");
    }

    private void runTimer() {

        h.post(new Runnable() {
            @Override
            public void run() {

                long millis = startTime - System.currentTimeMillis();
                int seconds = (int) (millis / 1000);
                int minutes = seconds / 60;
                seconds   = seconds % 60;

                if (millis > 0) {
                    t.setText(String.format("%d:%02d", minutes, seconds));
                } else {
                    games = false;
                    t.setText("Your score : " + clicks + "");

                    if(bastScore < clicks)
                        bastScore = clicks;

                    getSupportActionBar().setTitle("Best Score : " + bastScore);
                    b.setText("Start new game");

                    h.removeCallbacks(this);
                }
                h.postDelayed(this, 100);
            }
        });
    }


}