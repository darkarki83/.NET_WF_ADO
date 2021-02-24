package com.artk.runline;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.os.Handler;
import android.widget.Button;

public class MainActivity extends AppCompatActivity {

    Button b;
    Handler h = new Handler();
    String title = "Artem Krol Shalom ";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        b = findViewById(R.id.button);

        getSupportActionBar().setTitle(title);
        b.setText(title);
        runLine();
    }

    private void runLine() {

        h.post(new Runnable() {
            @Override
            public void run() {

                title = title.substring(1) + title.substring(0,1);
                b.setText(title);
                getSupportActionBar().setTitle(title);

                h.postDelayed(this, 700);
            }
        });
    }
}