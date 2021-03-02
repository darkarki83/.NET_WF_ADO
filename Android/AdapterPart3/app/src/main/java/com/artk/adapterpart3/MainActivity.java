package com.artk.adapterpart3;

import android.os.Bundle;
import android.view.View;
import android.content.Context;
import android.view.ViewGroup;
import android.widget.ImageView;

import android.app.ListActivity;
import android.view.LayoutInflater;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import com.bumptech.glide.Glide;

class MyArrayAdapter extends ArrayAdapter<String> {

    private final Context context;
    private final String[] descriptions;
    private final String[] urls;

    public MyArrayAdapter(Context context, String[] descriptions, String[] urls) {
        super(context, R.layout.item, descriptions);
        this.context = context;
        this.descriptions = descriptions;
        this.urls = urls;
    }

    // getView - запускается андроидом автоматически в момент генерации очередного пукта списка
    // если пунктов 4 - то этот метод сработает 4 раза, с position"ами 0 1 2 3
    @Override
    public View getView(int position, View convertView, ViewGroup parent) {

        // LayoutInflater - специальная фоновая служба ОС Android, которая позволяет сгенерить Java-объекты на основании XML-вёрстки
        LayoutInflater inflater = (LayoutInflater) context
                .getSystemService(Context.LAYOUT_INFLATER_SERVICE);

        // rowView - это будет ссылка на корневой лэяут (в данном случае это LinearLayout из файла item.xml
        View rowView = inflater.inflate(R.layout.item, parent, false);
        TextView textView = rowView.findViewById(R.id.label);
        ImageView imageView = rowView.findViewById(R.id.logo);

        // момент прогрузки данных в пункты списка:
        textView.setText(descriptions[position]);

        // https://github.com/bumptech/glide
        Glide.with(context).load(urls[position]).into(imageView);

        return rowView;
    }
}

public class MainActivity extends ListActivity {

    static String[] descriptions = new String[]{"cat", "dog", "pikachu", "car"};

    static String[] urls = new String[]{"https://news.cgtn.com/news/77416a4e3145544d326b544d354d444d3355444f31457a6333566d54/img/37d598e5a04344da81c76621ba273915/37d598e5a04344da81c76621ba273915.jpg",
            "https://dynaimage.cdn.cnn.com/cnn/c_fill,g_auto,w_1200,h_675,ar_16:9/https%3A%2F%2Fcdn.cnn.com%2Fcnnnext%2Fdam%2Fassets%2F200703104728-labrador-retriever-stock.jpg",
            "https://b1.filmpro.ru/c/569968.700xp.jpg",
            "https://media.wired.com/photos/5d09594a62bcb0c9752779d9/125:94/w_1994,h_1500,c_limit/Transpo_G70_TA-518126.jpg"};

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setListAdapter(new MyArrayAdapter(this, descriptions, urls));
    }

    @Override
    protected void onListItemClick(ListView l, View v, int position, long id) {
        String selectedValue = (String) getListAdapter().getItem(position);
        Toast.makeText(this, selectedValue, Toast.LENGTH_SHORT).show();
    }
}