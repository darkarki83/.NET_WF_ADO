package com.artk.notification;

/*     first example
import android.app.Notification;
import android.app.NotificationChannel;
import android.app.NotificationManager;
import android.app.PendingIntent;
import android.content.Context;
import android.content.Intent;
import android.content.res.Resources;
import android.graphics.BitmapFactory;
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

        NotificationManager manager = (NotificationManager) getSystemService(Context.NOTIFICATION_SERVICE);
        NotificationCompat.Builder builder;

        Context context = getApplicationContext();
        Resources res = context.getResources();

        // начиная с Android 8, требуются каналы уведомлений
        if (android.os.Build.VERSION.SDK_INT >= android.os.Build.VERSION_CODES.O) {

            String CHANNEL_ID = "artem_channel";

            // https://developer.android.com/training/notify-user/channels
            // https://medium.com/exploring-android/exploring-android-o-notification-channels-94cd274f604c
            // https://startandroid.ru/ru/uroki/vse-uroki-spiskom/515-urok-190-notifications-kanaly.html
            // https://code.tutsplus.com/ru/tutorials/android-o-how-to-use-notification-channels--cms-28616

            NotificationChannel channel = new NotificationChannel(CHANNEL_ID, "AlexChannel",
                    NotificationManager.IMPORTANCE_LOW);
            channel.setDescription("Artem channel description");
            manager.createNotificationChannel(channel);

            builder = new NotificationCompat.Builder(this, CHANNEL_ID);
        }
        else
        {
            builder = new NotificationCompat.Builder(context);
        }

        // https://developer.android.com/reference/android/app/PendingIntent
        PendingIntent action = PendingIntent.getActivity(context,
                0, new Intent(context, MainActivity.class),
                PendingIntent.FLAG_CANCEL_CURRENT); // Flag indicating that if the described PendingIntent already exists, the current one should be canceled before generating a new one.

        builder.setContentIntent(action)
                .setLargeIcon(BitmapFactory.decodeResource(res, R.drawable.ic_baseline_child_care_24))
                .setSmallIcon(R.drawable.ic_baseline_child_care_24)
                .setTicker("Small text!")
                .setAutoCancel(true) // make this notification automatically dismissed when the user touches it
                .setContentTitle("Privet ot nas")
                .setContentText("Welcome");

        Notification notification = builder.build();

        int notificationCode = (int) (Math.random() * 1000);
        manager.notify(notificationCode, notification);
    }
}*/

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

        NotificationManager manager = (NotificationManager) getSystemService(Context.NOTIFICATION_SERVICE);
        NotificationCompat.Builder builder;

        Context context = getApplicationContext();
        Resources res = context.getResources();

        if (android.os.Build.VERSION.SDK_INT >= android.os.Build.VERSION_CODES.O) {

            String CHANNEL_ID = "artem_channel";

            NotificationChannel channel = new NotificationChannel(CHANNEL_ID, "ArtemChannel",
                    NotificationManager.IMPORTANCE_HIGH);
            channel.setDescription("Artem channel description");
            manager.createNotificationChannel(channel);

            builder = new NotificationCompat.Builder(this, CHANNEL_ID);
        }
        else
        {
            builder = new NotificationCompat.Builder(context);
        }

        // OPEN SOME WEB PAGE:
        PendingIntent action = PendingIntent.getActivity(context,
                0, new Intent(Intent.ACTION_VIEW, Uri.parse("https://t.me/artkrol")),
                PendingIntent.FLAG_CANCEL_CURRENT); // Flag indicating that if the described PendingIntent already exists, the current one should be canceled before generating a new one.

        builder.setContentIntent(action)
                .setLargeIcon(BitmapFactory.decodeResource(res, R.drawable.ic_baseline_child_care_24))
                .setSmallIcon(R.drawable.ic_baseline_child_care_24)
                .setTicker("Opening Telegram...")
                .setAutoCancel(true) // make this notification automatically dismissed when the user touches it
                .setContentTitle("Telegram")
                .setDefaults(Notification.DEFAULT_SOUND) // убедитесь, что отключён беззвучный режим!
                .setContentText("Open Artem  Telegram");

        Notification notification = builder.build();

        manager.notify(101, notification);
    }
}