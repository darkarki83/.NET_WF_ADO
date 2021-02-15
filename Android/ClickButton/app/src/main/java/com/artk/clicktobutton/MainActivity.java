package com.artk.clicktobutton;

import androidx.appcompat.app.AppCompatActivity;

import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.graphics.drawable.Drawable;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.Toast;

import java.util.Random;

public class MainActivity extends AppCompatActivity {

    private int count  = 0;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        // set Listener (Add listener to button)
        Button b = findViewById(R.id.b1);

        b.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View v) {
                //count++;  // work
                //b.setText(count + "");  // work
                Toast.makeText(MainActivity.this, "Yes", Toast.LENGTH_SHORT).show();
            }
        });

    }

    /*public void fun(View view) {
        count++;
        // 1)  MY Version
        //Toast.makeText(this, String.valueOf(count), Toast.LENGTH_SHORT).show();


        // 2)  Change Button
        //Button b = (Button)view;
        //b.setText(String.valueOf(count));

        // 3)  Change Title (ActionBar)
        //getSupportActionBar().setTitle(count + "");

        // Change Action Bar color
        /*
        Random rand = new Random();

        getSupportActionBar().setBackgroundDrawable(
                new ColorDrawable(Color.rgb(
                        rand.nextInt(255), rand.nextInt(255), rand.nextInt(255))));

         */
    //}


    /*
    * add Button ftom java
    *
    * package com.example.buttons;
    import androidx.appcompat.app.AppCompatActivity;
    import androidx.constraintlayout.widget.ConstraintLayout;
    import androidx.constraintlayout.widget.ConstraintSet;
    import android.graphics.Color;
    import android.os.Bundle;
    import android.view.Gravity;
    import android.view.View;
    import android.widget.Button;
    import android.widget.ImageView;
    import android.widget.LinearLayout;
    import android.widget.TextView;
    import android.widget.Toast;
    public class MainActivity extends AppCompatActivity {
    Button b; // поле типа Button для обращения к кнопке из любого метода активити
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        b = new Button(this);
        b.setId(View.generateViewId());
        ConstraintLayout layout = findViewById(R.id.layout);
        ConstraintSet set = new ConstraintSet();
        set.clone(layout);
        b.setText("PUSH ME!");
        b.setBackgroundColor(Color.rgb(255, 0, 0));
        layout.addView(b);
        set.connect(b.getId(), ConstraintSet.LEFT, layout.getId(), ConstraintSet.LEFT, 0);
        set.connect(b.getId(), ConstraintSet.RIGHT, layout.getId(), ConstraintSet.RIGHT, 0);
        set.connect(b.getId(), ConstraintSet.BOTTOM, layout.getId(), ConstraintSet.BOTTOM, 0);
        set.constrainWidth(b.getId(), ConstraintSet.MATCH_CONSTRAINT);
        set.constrainHeight(b.getId(), 200);
        set.applyTo(layout);
        b.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Toast toast = Toast.makeText(getApplicationContext(),
                        "Мой текст", Toast.LENGTH_LONG);
                LinearLayout toastContainer = (LinearLayout) toast.getView();
                TextView toastText = (TextView) toastContainer.getChildAt(0);
                toastText.setTextSize(35);
                ImageView img = new ImageView(getApplicationContext());
                img.setImageResource(R.drawable.cat);
                toastContainer.addView(img, 0);
                toast.setGravity(Gravity.FILL_HORIZONTAL | Gravity.BOTTOM, 0, 0);
                toast.show();
            }
        });
    }
}
    * */
}