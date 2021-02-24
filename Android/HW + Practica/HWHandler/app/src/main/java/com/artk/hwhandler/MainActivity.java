package com.artk.hwhandler;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.constraintlayout.widget.ConstraintLayout;
import android.os.Bundle;
import android.os.Handler;
import android.widget.Button;
import android.widget.LinearLayout;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {

    Handler handler = new Handler();
    String INFO = "ArtemP_";
    int num = 0;
    Button b;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        b = findViewById(R.id.button);
        runTimer();
    }

    @Override
    protected void onSaveInstanceState(@NonNull Bundle outState) {
        super.onSaveInstanceState(outState);
        outState.putInt("num", num);
    }

    @Override
    protected void onRestoreInstanceState(@NonNull Bundle savedInstanceState) {
        super.onRestoreInstanceState(savedInstanceState);
        num = savedInstanceState.getInt("num");
    }

    private void runTimer() {

        handler.post(new Runnable() {
            @Override
            public void run() {
                num++;

                ConstraintLayout.LayoutParams params = (ConstraintLayout.LayoutParams)b.getLayoutParams();
                params.setMargins(num, 0, 0, 0);
                b.setLayoutParams(params);

                handler.postDelayed(this, 1);
            }
        });
    }
}