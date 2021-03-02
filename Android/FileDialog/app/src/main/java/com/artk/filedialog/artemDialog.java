package com.artk.filedialog;
import android.app.Dialog;
import android.graphics.Color;
import android.os.Bundle;
import android.widget.Toast;

import androidx.appcompat.app.AlertDialog;
import androidx.fragment.app.DialogFragment;


public class artemDialog extends DialogFragment {
    @Override
    public Dialog onCreateDialog(Bundle savedInstanceState) {

        AlertDialog.Builder builder = new AlertDialog.Builder(getActivity());
        builder.setTitle("Очень важное сообщение!")
                .setIcon(R.drawable.enot)
                .setMessage("Срочно покормите енота!")
                .setPositiveButton("Будет сделано!", (dialog, id) -> Toast.makeText(getActivity().getApplicationContext(),
                        "кормим енота вкусняшками", Toast.LENGTH_SHORT).show())
                .setNegativeButton("Он не голодный!", (dialog, id) -> Toast.makeText(getActivity().getApplicationContext(),
                        "отмена работы с диалогом", Toast.LENGTH_SHORT).show())
                .setNeutralButton("не знаю", (dialog, id) -> Toast.makeText(getActivity().getApplicationContext(),
                "отмена работы с диалогом", Toast.LENGTH_SHORT).show());

        return builder.create();
    }

    @Override
    public void onStart() {
        super.onStart();
        ((AlertDialog) getDialog()).getButton(AlertDialog.BUTTON_POSITIVE).setTextColor(Color.BLUE);
        ((AlertDialog) getDialog()).getButton(AlertDialog.BUTTON_NEGATIVE).setTextColor(Color.RED);
        ((AlertDialog) getDialog()).getButton(AlertDialog.BUTTON_NEUTRAL).setTextColor(Color.GREEN);
    }

}
