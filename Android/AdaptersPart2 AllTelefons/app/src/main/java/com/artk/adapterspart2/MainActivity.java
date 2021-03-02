package com.artk.adapterspart2;

import android.Manifest;
import android.app.ListActivity;
import android.content.ContentResolver;
import android.content.ContentUris;
import android.database.Cursor;
import android.net.Uri;
import android.provider.ContactsContract;
import android.os.Bundle;
import android.widget.SimpleAdapter;


import com.karumi.dexter.Dexter;
import com.karumi.dexter.MultiplePermissionsReport;
import com.karumi.dexter.PermissionToken;
import com.karumi.dexter.listener.PermissionRequest;
import com.karumi.dexter.listener.multi.MultiplePermissionsListener;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

public class MainActivity extends ListActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        runDexter();
    }

    private void runDexter() {
        Dexter.withContext(this)
                .withPermissions(Manifest.permission.READ_CONTACTS,
                        Manifest.permission.WRITE_CONTACTS)
                .withListener(new MultiplePermissionsListener() {
                    @Override
                    public void onPermissionsChecked(MultiplePermissionsReport report) {
                        ArrayList<HashMap<String, Object>> items = new ArrayList<>();
                        String[] from = {"name", "number", "uri"};
                        int[] to = {R.id.name, R.id.number, R.id.image};
                        SimpleAdapter adapter = new SimpleAdapter(MainActivity.this, items, R.layout.my_item, from, to);
                        setListAdapter(adapter);
                        ContentResolver contentResolver = getContentResolver();
                        Cursor cursor = contentResolver.query(ContactsContract.Contacts.CONTENT_URI, null,
                                null, null, null);
                        if (cursor.getCount() > 0) {
                            while (cursor.moveToNext()) {
                                HashMap<String, Object> data = new HashMap<>();
                                String id = cursor.getString(cursor.getColumnIndex(ContactsContract.Contacts._ID));
                                data.put("id", id);
                                data.put("name", cursor.getString(cursor.getColumnIndex(ContactsContract.Contacts.DISPLAY_NAME)));
                                if (cursor.getInt(cursor.getColumnIndex(ContactsContract.Contacts.HAS_PHONE_NUMBER)) == 1) {
                                    Cursor phoneCursor = contentResolver.query(
                                            ContactsContract.CommonDataKinds.Phone.CONTENT_URI,
                                            null,
                                            ContactsContract.CommonDataKinds.Phone.CONTACT_ID + " = ?",
                                            new String[]{id},
                                            null);

                                    while (phoneCursor.moveToNext()) {
                                        data.put("number", phoneCursor.getString(phoneCursor.getColumnIndex(ContactsContract.CommonDataKinds.Phone.NUMBER)));
                                        items.add(data);
                                        Uri uri = getPhotoUri(Long.parseLong(id));
                                        if (uri != null) {
                                            data.put("uri", getPhotoUri(Long.parseLong(id)));
                                        } else {
                                            data.put("uri", R.drawable.ic_launcher_foreground);
                                        }
                                        adapter.notifyDataSetChanged();
                                    }

                                    phoneCursor.close();
                                }
                            }
                        }
                    }

                    @Override
                    public void onPermissionRationaleShouldBeShown(List<PermissionRequest> permissions, PermissionToken token) {

                    }
                }).check();
    }

    public Uri getPhotoUri(long id) {
        try {
            Cursor cur = getContentResolver().query(
                    ContactsContract.Data.CONTENT_URI,
                    null,
                    ContactsContract.Data.CONTACT_ID + "=" + String.valueOf(id) + " AND "
                            + ContactsContract.Data.MIMETYPE + "='"
                            + ContactsContract.CommonDataKinds.Photo.CONTENT_ITEM_TYPE + "'", null,
                    null);
            if (cur != null) {
                if (!cur.moveToFirst()) {
                    return null; // no photo
                }
            } else {
                return null; // error in cursor process
            }
        } catch (Exception e) {
            e.printStackTrace();
            return null;
        }
        Uri person = ContentUris.withAppendedId(ContactsContract.Contacts.CONTENT_URI, id);
        return Uri.withAppendedPath(person, ContactsContract.Contacts.Photo.CONTENT_DIRECTORY);
    }

}