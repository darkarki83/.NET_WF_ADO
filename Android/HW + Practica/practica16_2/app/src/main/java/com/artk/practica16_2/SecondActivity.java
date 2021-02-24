package com.artk.practica16_2;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.Toast;

public class SecondActivity extends AppCompatActivity {

    int count;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_second);

        getSupportActionBar().setTitle(this.hashCode() + "");

      /*  Button b = findViewById(R.id.button);

        b.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                count++;

                Intent i = new Intent(this, MainActivity.class);



            }
        });
        //count = i*/

        count = getIntent().getIntExtra("count", 0);
    }

    @Override
    protected void onSaveInstanceState(@NonNull Bundle outState) {
        super.onSaveInstanceState(outState);

        outState.putInt("count", count);
    }

    @Override
    protected void onRestoreInstanceState(@NonNull Bundle savedInstanceState) {
        super.onRestoreInstanceState(savedInstanceState);

        count = savedInstanceState.getInt("count");
    }

    public void ToMain(View view) {
        count++;

        Intent i = new Intent();
        i.putExtra("count", count);
        setResult(200, i);

        Toast.makeText(this, count + "", Toast.LENGTH_SHORT).show();
        finish();
    }
}