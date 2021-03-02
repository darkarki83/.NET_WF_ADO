package com.artk.myapplication;

import android.content.Context;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.GridView;
import android.widget.ImageView;

import androidx.appcompat.app.AppCompatActivity;

import com.bumptech.glide.Glide;

class CustomAdapter extends BaseAdapter {
    Context context;
    LayoutInflater inf;
    private String[] descriptions;
    private String[] urls;

    public CustomAdapter(Context applicationContext, String[] descriptions, String[] urls) {
        this.context = applicationContext;
        this.descriptions = descriptions;
        this.urls = urls;

        inf = (LayoutInflater.from(applicationContext));
    }

    @Override
    public int getCount() {
        return urls.length;
    }

    @Override
    public Object getItem(int i) {
        return null;
    }

    @Override
    public long getItemId(int i) {
        return 0;
    }

    @Override
    public View getView(int i, View view, ViewGroup viewGroup) {
        view = inf.inflate(R.layout.my_item, null);
        ImageView icon = (ImageView) view.findViewById(R.id.icon);

        Glide.with(context).load(urls[i]).into(icon);

        return view;
    }
}

public class MainActivity extends AppCompatActivity {

    GridView simpleGrid;

    static String[] descriptions = new String[]{"cat", "dog", "pikachu", "car", "supercat","dj","up","usa","cat", "dog", "pikachu", "car","supercat","dj","up","usa","cat", "dog", "pikachu", "car"};
    static String[] urls = new String[]{"https://news.cgtn.com/news/77416a4e3145544d326b544d354d444d3355444f31457a6333566d54/img/37d598e5a04344da81c76621ba273915/37d598e5a04344da81c76621ba273915.jpg",
            "https://dynaimage.cdn.cnn.com/cnn/c_fill,g_auto,w_1200,h_675,ar_16:9/https%3A%2F%2Fcdn.cnn.com%2Fcnnnext%2Fdam%2Fassets%2F200703104728-labrador-retriever-stock.jpg",
            "https://b1.filmpro.ru/c/569968.700xp.jpg",
            "https://media.wired.com/photos/5d09594a62bcb0c9752779d9/125:94/w_1994,h_1500,c_limit/Transpo_G70_TA-518126.jpg", "https://worldwideinter.wpengine.com/wp-content/uploads/2016/08/best-pictures-of-the-internet.jpg","https://worldwideinter.wpengine.com/wp-content/uploads/2016/08/best-photo-on-the-internet.jpg","https://worldwideinter.wpengine.com/wp-content/uploads/2016/08/pictures-on-the-internet.jpg","https://worldwideinter.wpengine.com/wp-content/uploads/2016/08/pictures-on-internet.jpg","https://news.cgtn.com/news/77416a4e3145544d326b544d354d444d3355444f31457a6333566d54/img/37d598e5a04344da81c76621ba273915/37d598e5a04344da81c76621ba273915.jpg",
            "https://dynaimage.cdn.cnn.com/cnn/c_fill,g_auto,w_1200,h_675,ar_16:9/https%3A%2F%2Fcdn.cnn.com%2Fcnnnext%2Fdam%2Fassets%2F200703104728-labrador-retriever-stock.jpg",
            "https://b1.filmpro.ru/c/569968.700xp.jpg",
            "https://media.wired.com/photos/5d09594a62bcb0c9752779d9/125:94/w_1994,h_1500,c_limit/Transpo_G70_TA-518126.jpg",
            "https://worldwideinter.wpengine.com/wp-content/uploads/2016/08/best-pictures-of-the-internet.jpg",
            "https://worldwideinter.wpengine.com/wp-content/uploads/2016/08/best-photo-on-the-internet.jpg",
            "https://worldwideinter.wpengine.com/wp-content/uploads/2016/08/pictures-on-the-internet.jpg",
            "https://worldwideinter.wpengine.com/wp-content/uploads/2016/08/pictures-on-internet.jpg",
            "https://news.cgtn.com/news/77416a4e3145544d326b544d354d444d3355444f31457a6333566d54/img/37d598e5a04344da81c76621ba273915/37d598e5a04344da81c76621ba273915.jpg",
            "https://dynaimage.cdn.cnn.com/cnn/c_fill,g_auto,w_1200,h_675,ar_16:9/https%3A%2F%2Fcdn.cnn.com%2Fcnnnext%2Fdam%2Fassets%2F200703104728-labrador-retriever-stock.jpg",
            "https://b1.filmpro.ru/c/569968.700xp.jpg",
            "https://media.wired.com/photos/5d09594a62bcb0c9752779d9/125:94/w_1994,h_1500,c_limit/Transpo_G70_TA-518126.jpg"};

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        simpleGrid = findViewById(R.id.simpleGridView);
        CustomAdapter customAdapter = new CustomAdapter(getApplicationContext(), descriptions, urls);
        simpleGrid.setAdapter(customAdapter);
    }
}