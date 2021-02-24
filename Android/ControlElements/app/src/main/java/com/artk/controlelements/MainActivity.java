package com.artk.controlelements;

import android.app.Activity;
import android.graphics.Color;
import android.graphics.drawable.Drawable;
import android.os.Bundle;
import android.text.Editable;
import android.text.TextWatcher;
import android.view.View;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.RadioButton;
import android.widget.RadioGroup;
import android.widget.TextView;
import android.widget.Toast;

/*
Отслеживание нажатия клавиатуры

public class MainActivity extends Activity {
    private EditText passwordEditText;
    private TextView textView;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        /* Initializing views
        passwordEditText = (EditText) findViewById(R.id.password);
        textView = (TextView) findViewById(R.id.passwordHint);
        textView.setVisibility(View.GONE);

        /* Set Text Watcher listener
        passwordEditText.addTextChangedListener(passwordWatcher);
    }

    private final TextWatcher passwordWatcher = new TextWatcher() {
        public void beforeTextChanged(CharSequence s, int start, int count, int after) {

        }

        public void onTextChanged(CharSequence s, int start, int before, int count) {
            textView.setVisibility(View.VISIBLE);
        }

        public void afterTextChanged(Editable s) {
            if (s.length() == 0) {
                textView.setVisibility(View.GONE);
            } else{
                textView.setText("You have entered : " + passwordEditText.getText());
            }
        }
    };
}

 */
public class MainActivity extends Activity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        RadioGroup r = findViewById(R.id.group);

        r.setOnCheckedChangeListener(new RadioGroup.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(RadioGroup group, int checkedId) {

                int id = r.getCheckedRadioButtonId();
                if(id == -1){
                    Toast.makeText(MainActivity.this, "Click to the button" + "", Toast.LENGTH_SHORT).show();
                } else{
                    RadioButton rb = findViewById(id);
                    LinearLayout l = findViewById(R.id.layout);

                    if(rb.getId() == (int)2131231014){
                        l.setBackgroundColor(Color.parseColor("#DD1111"));
                    }
                    else if(rb.getId() == (int)2131231015){
                        l.setBackgroundColor(Color.parseColor("#4CAF50"));
                    }
                    else if(rb.getId() == (int)2131231016){
                        l.setBackgroundColor(Color.parseColor("#1316D5"));
                    }
                    else if(rb.getId() == (int)2131231017){
                        l.setBackgroundColor(Color.parseColor("#FFEB3B"));
                    }

                }
                //Toast.makeText(MainActivity.this, dd.getText() + "", Toast.LENGTH_SHORT).show();
            }
        });
    }

   /* public void clickRadio(View view) {

    }*/
}