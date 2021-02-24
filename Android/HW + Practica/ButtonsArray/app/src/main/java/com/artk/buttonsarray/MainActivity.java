package com.artk.buttonsarray;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import android.os.Bundle;
import android.view.ContextMenu;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.GridLayout;
import android.widget.Toast;
public class MainActivity extends AppCompatActivity {
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        GridLayout layout = findViewById(R.id.layout);
        layout.setColumnCount(10);
        Button[][] b = new Button[6][10];

        for (int i = 0; i < b.length; i++) {
            for (int j = 0; j < b[i].length; j++){

                GridLayout.LayoutParams layoutParams = new GridLayout.LayoutParams();
                layoutParams.setMargins(10, 10, 10, 10);
                layoutParams.width = 160;
                layoutParams.height = 160;
                b[i][j] = new Button(this);
                b[i][j].setLayoutParams(layoutParams);
                b[i][j].setText((j + 1) * (i + 1) + "");
                b[i][j].setOnClickListener(new View.OnClickListener() {
                    @Override
                    public void onClick(View view) {
                        view.setVisibility(View.GONE);
                    }
                });
                layout.addView(b[i][j]);
            }
        }
       /* for (int i = 0; i < 100; i++) {
            GridLayout.LayoutParams layoutParams = new GridLayout.LayoutParams();
            layoutParams.setMargins(10, 10, 10, 10);
            layoutParams.width = 160;
            layoutParams.height = 160;
            b[i] = new Button(this);
            b[i].setLayoutParams(layoutParams);
            b[i].setText(i + "");

            b[i].setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View view) {
                    view.setVisibility(View.GONE);
                }
            });

            layout.addView(b[i]);
        }*/
    }
}

