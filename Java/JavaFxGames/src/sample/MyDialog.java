package sample;

import javafx.scene.control.Alert;

public class MyDialog {

    private Alert alert;
    private boolean winOrno;   // может нужно будет на будущее

    public MyDialog(Alert alert, String title, String contentText, boolean winOrno) {
        //region 1.2

        this.winOrno = winOrno;

        this.alert = alert;
        this.alert.setTitle(title);
        this.alert.setHeaderText(null);
        this.alert.setContentText(title + contentText);

        this.alert.showAndWait();
        //endregion
    }
}
