package com.artk.hwdialog;

import android.app.Activity;
import android.app.Dialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.graphics.Color;
import android.net.Uri;
import android.os.Bundle;
import android.widget.EditText;
import android.widget.Toast;

import androidx.appcompat.app.AlertDialog;
import androidx.fragment.app.DialogFragment;

public class ArtemDialog extends DialogFragment {

    String title;
    String massage;

    public ArtemDialog(String title, String massage){
        this.title = title;
        this.massage = massage;
    }

    @Override
    public Dialog onCreateDialog(Bundle savedInstanceState) {

        AlertDialog.Builder builder = new AlertDialog.Builder(getActivity());
        builder.setTitle(title)
                .setIcon(R.drawable.enot)
                .setMessage(massage)
                .setPositiveButton("Yes!", new DialogInterface.OnClickListener() {

                    @Override
                    public void onClick(DialogInterface dialog, int which) {

                        dialog.cancel();

                        Activity a = getActivity();

                        AlertDialog.Builder builder1 = new AlertDialog.Builder(a);
                        builder1.setMessage("App store, then")
                                .setPositiveButton("ok, sure", new DialogInterface.OnClickListener() {
                                    @Override
                                    public void onClick(DialogInterface dialog1, int whichs1) {

                                        Intent intent = new Intent(Intent.ACTION_VIEW);
                                        intent.setData(Uri.parse("https://play.google.com/store/apps/details?id=com.example.android.example"));
                                        intent.setPackage("com.android.vending");

                                        a.getApplicationContext().startActivity(intent);
                                        dialog1.cancel();
                                    }
                                })
                                .setNegativeButton("No,thanks" , new DialogInterface.OnClickListener() {
                                    @Override
                                    public void onClick(DialogInterface dialog2, int which2) {

                                        Toast.makeText(a.getApplicationContext(), "Have a nice day", Toast.LENGTH_SHORT).show();
                                        dialog2.cancel();
                                    }
                                })
                                .create();
                        builder1.show();
                    }
                })
                .setNegativeButton("Not really", new DialogInterface.OnClickListener() {

                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        dialog.cancel();

                        Activity a = getActivity();

                        AlertDialog.Builder builder1 = new AlertDialog.Builder(a);
                        builder1.setMessage("Would you mind giving us some feedback?")
                                .setPositiveButton("Ok, sure", new DialogInterface.OnClickListener() {
                                    @Override
                                    public void onClick(DialogInterface dialog1, int which1) {
                                        /*final Dialog alert  = new Dialog(a.getApplicationContext());
                                        alert.setContentView(R.layout.dialog);*/
                                        //EditText text1 = (EditText)alert.findViewById(R.id.editTextTextMultiLine);

                                        AlertDialog.Builder builder = new AlertDialog.Builder(a);
                                        builder.setTitle("your comment");
                                        builder.setView(R.layout.dialog);
                                        builder.setPositiveButton("Send", new DialogInterface.OnClickListener() {
                                            @Override
                                            public void onClick(DialogInterface dialog1, int whichs1) {

                                                Dialog alert  = Dialog.class.cast(dialog1);
                                                EditText text1 = (EditText)alert.findViewById(R.id.editTextTextMultiLine);
                                                
                                                Toast.makeText(a.getApplicationContext(), text1.getText().toString(), Toast.LENGTH_SHORT).show();
                                                dialog1.cancel();
                                            }
                                        });

                                        builder.create();
                                        builder.show();
                                    }
                                })
                                .setNegativeButton("No,thanks" , new DialogInterface.OnClickListener() {
                                    @Override
                                    public void onClick(DialogInterface dialog2, int which2) {

                                        Toast.makeText(a.getApplicationContext(), "Have a nice day", Toast.LENGTH_SHORT).show();
                                        dialog2.cancel();
                                    }
                                })
                                .create();
                        builder1.show();
                    }
                });
        return builder.create();
    }
    @Override
    public void onStart() {
        super.onStart();
        ((AlertDialog) getDialog()).getButton(AlertDialog.BUTTON_POSITIVE).setTextColor(Color.BLUE);
        ((AlertDialog) getDialog()).getButton(AlertDialog.BUTTON_NEGATIVE).setTextColor(Color.RED);
    }
}
