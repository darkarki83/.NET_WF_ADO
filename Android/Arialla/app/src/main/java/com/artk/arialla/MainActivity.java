package com.artk.arialla;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.Gravity;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.TextView;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.List;

public class MainActivity extends AppCompatActivity {

    private List<ImageView> images;
    private int index = 0;

    private Object[] objects;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        images = new ArrayList<>();

        ImageView img1_1 = new ImageView(getApplicationContext());
        img1_1.setImageResource(R.drawable.number1);
        images.add(img1_1);

        ImageView img = new ImageView(getApplicationContext());
        img.setImageResource(R.drawable.arialla);
        images.add(img);

        ImageView img2_1 = new ImageView(getApplicationContext());
        img2_1.setImageResource(R.drawable.number2);
        images.add(img2_1);

        ImageView img2 = new ImageView(getApplicationContext());
        img2.setImageResource(R.drawable.ariallam);
        images.add(img2);

        ImageView img3_1 = new ImageView(getApplicationContext());
        img3_1.setImageResource(R.drawable.number3);
        images.add(img3_1);

        ImageView img3 = new ImageView(getApplicationContext());
        img3.setImageResource(R.drawable.ariallamp);
        images.add(img3);

        ImageView img4_1 = new ImageView(getApplicationContext());
        img4_1.setImageResource(R.drawable.number4);
        images.add(img4_1);

        ImageView img4 = new ImageView(getApplicationContext());
        img4.setImageResource(R.drawable.ariallaba);
        images.add(img4);

    }

    public void run(View view) {
        String  size = "ArrayList has " + images.size() + " elements";

        Toast toast = Toast.makeText(getApplicationContext(),
                size, Toast.LENGTH_LONG);
        LinearLayout toastContainer = (LinearLayout) toast.getView();

        if(images.get(index).getParent() != null) {
            ((ViewGroup)images.get(index).getParent()).removeView(images.get(index)); // <- fix
                          // решает проблему повторного использования ресурса
        }

        toastContainer.addView(images.get(index), 0);

        this.indexator();

        toast.setGravity(Gravity.FILL_HORIZONTAL | Gravity.FILL_VERTICAL, 0, 0);
        toast.show();

    }

    private void indexator() {
        //index < (images.size() - 1) ? index++ : index = 0;

        if(index < images.size() - 1)
            index++;
        else
            index = 0;
    }
}