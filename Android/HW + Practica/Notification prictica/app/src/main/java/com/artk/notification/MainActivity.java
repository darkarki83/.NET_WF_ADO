package com.artk.notification;

import android.app.Notification;
import android.app.NotificationChannel;
import android.app.NotificationManager;
import android.app.PendingIntent;
import android.content.Context;
import android.content.Intent;
import android.content.res.Resources;
import android.graphics.BitmapFactory;
import android.net.Uri;
import android.os.Bundle;
import android.view.View;

import androidx.appcompat.app.AppCompatActivity;
import androidx.core.app.NotificationCompat;

public class MainActivity extends AppCompatActivity {

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }

    public void onClick(View view) {

        String bigText = "Suspendisse ac ex at nunc pulvinar lacinia.";

        NotificationManager manager = (NotificationManager) getSystemService(Context.NOTIFICATION_SERVICE);
        NotificationCompat.Builder builder;

        Context context = getApplicationContext();
        Resources res = context.getResources();

        if (android.os.Build.VERSION.SDK_INT >= android.os.Build.VERSION_CODES.O) {

            String CHANNEL_ID = "artem_channel";

            NotificationChannel channel = new NotificationChannel(CHANNEL_ID, "ArtemChannel",
                    NotificationManager.IMPORTANCE_HIGH);
            channel.setDescription("Artem channel description");

            channel.setSound(null, null);

            manager.createNotificationChannel(channel);

            builder = new NotificationCompat.Builder(getApplicationContext(), CHANNEL_ID);
        } else {
            builder = new NotificationCompat.Builder(context);
        }

        PendingIntent action = PendingIntent.getActivity(context,
                0, new Intent(Intent.ACTION_VIEW, Uri.parse("https://t.me/sunmeat")),
                PendingIntent.FLAG_CANCEL_CURRENT); // Flag indicating that if the described PendingIntent already exists, the current one should be canceled before generating a new one.

        builder.setContentTitle("Notification Title")
                .setContentText("Notification Content")
                .setTicker("Opening...")
                .setContentIntent(action)
                .setPriority(Notification.PRIORITY_HIGH) // приоритет для старых версий андроида
                .setLargeIcon(BitmapFactory.decodeResource(context.getResources(), R.drawable.ic_baseline_celebration_24))
                // http://stackoverflow.com/questions/35647821/android-notification-addaction-deprecated-in-api-23
                .addAction(R.drawable.enot, "1", action)
                .addAction(R.drawable.enot, "2", action/*2*/)
                .addAction(R.drawable.ic_launcher_background, "3", action/*3*/)
                .setSmallIcon(R.drawable.ic_baseline_celebration_24);

        /*Notification notification = new NotificationCompat.BigTextStyle(builder)
                .bigText(bigText).build();*/

        Notification notification = new NotificationCompat.BigPictureStyle(builder)
                .bigPicture(BitmapFactory.decodeResource(getResources(), R.drawable.rain)).build();

        manager.notify(101, notification);

    }
}