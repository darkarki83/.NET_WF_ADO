package com.artk.backgraundcolor;

import androidx.appcompat.app.AppCompatActivity;

import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.graphics.drawable.Drawable;
import android.os.Bundle;
import android.os.Handler;
import android.text.Layout;
import android.view.View;

public class MainActivity extends AppCompatActivity {

    View layout;
    Handler h = new Handler();
    int rColor = 0;
    int gColor = 0;
    int bColor = 0;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        layout = findViewById(R.id.layout);
        changeColor();
    }

    private void changeColor() {
        h.post(new Runnable() {
            @Override
            public void run() {
                addToColor();

                Drawable d = new ColorDrawable(Color.rgb(rColor, gColor, bColor));
                layout.setBackground(d);

                h.postDelayed(this, 100);
            }
        });
    }

    private void addToColor() {
        if(rColor < 255)
            rColor++;
        else if(gColor < 255)
            gColor++;
        else if(bColor < 255)
            bColor++;
        else if(bColor == 255){
            rColor = 0;
            gColor = 0;
            bColor = 0;
        }
    }
}

