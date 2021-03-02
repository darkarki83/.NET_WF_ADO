package com.artk.hwnotification;

import androidx.appcompat.app.AppCompatActivity;

import android.app.Notification;
import android.app.NotificationManager;
import android.app.PendingIntent;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.RemoteViews;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }

    public void onClick(View view) {
        startNotification();
    }

    private void startNotification() {
        String text = "Suspendisse ac ex at nunc pulvinar lacinia.";

        String ns = Context.NOTIFICATION_SERVICE;
        NotificationManager notificationManager =
                (NotificationManager) getSystemService(ns);

        Notification notification = new Notification(R.drawable.ic_android_black_24dp, null,
                System.currentTimeMillis());

        RemoteViews notificationView = new RemoteViews(getPackageName(),
                R.layout.mynotification);

        //the intent that is started when the notification is clicked (works)
        PendingIntent pendingNotificationIntent = PendingIntent.getActivity(this, 0,
                new Intent(Intent.ACTION_VIEW, Uri.parse("https://t.me/sunmeat")), 0);

        notification.contentView = notificationView;
        notification.contentIntent = pendingNotificationIntent;
        notification.flags |= Notification.FLAG_NO_CLEAR;

        //this is the intent that is supposed to be called when the
        //button is clicked
        Intent switchIntent = new Intent(this, switchButtonListener.class);
        PendingIntent pendingSwitchIntent = PendingIntent.getBroadcast(this, 0,
                switchIntent, 0);

        notificationView.setOnClickPendingIntent(R.id.closeOnFlash,
                pendingSwitchIntent);

        notificationManager.notify(1, notification);
    }


    public static class switchButtonListener extends BroadcastReceiver {
        @Override
        public void onReceive(Context context, Intent intent) {
            Log.d("Here", "I am here");
        }
    }
}