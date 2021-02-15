package sample;

import javafx.application.Application;
import javafx.geometry.Insets;
import javafx.scene.Scene;
import javafx.scene.control.Alert;
import javafx.scene.image.Image;
import javafx.scene.image.ImageView;
import javafx.scene.input.KeyCode;
import javafx.scene.input.KeyEvent;
import javafx.scene.layout.ColumnConstraints;
import javafx.scene.layout.GridPane;
import javafx.scene.layout.RowConstraints;
import javafx.stage.Stage;

import java.util.Random;

public class Main extends Application {

    private int medalCount;   // medal count
    private MyDialog dialog;   // dialog close or win games

    {
        dialog = null;
        medalCount = 0;
    }

    public int getModelCount() {
        return medalCount;
    }
    public void setModelCount(int medalCount) {
        this.medalCount = medalCount;
    }

    public static void main(String[] args) {
        launch(args); // по сути, запуск метода start
    }

    @Override
    public void start(Stage primaryStage) {
        options(primaryStage); // первоначальные настройки приложения
        generateMaze(); // создание лабиринта
        showMaze(); // показ лабиринта
        gameProcess(); // начало игрового процесса (управление стрелками и тд.)
    }

    //[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
    //][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][
    //[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
    /// ПЕРЕМЕННЫЕ КЛАССА, которые будут доступны во всех методах:
    int height = 40; // высота лабиринта (количество строк)
    int width = 80; // ширина лабиринта (количество столбцов в каждой строке)

    enum GameObject {
        HALL, WALL, CHAR, CASH, ENEMY, HEALTH, COFFEE // BOMB, ENEMY2, BOSS ...
    };

    int countFromCoffee = 0;   // count moves after coffee
    boolean isEatCoffee = false;  // you drink coffee => start  counter

    boolean isSaveImage = false; // you need put image back?

    GameObject[][] maze = new GameObject[height][width];

    ImageView[][] images = new ImageView[height][width]; // массив ссылок
    // на элементы управления, на которых будут размещены картинки

    // пути к картинкам
    Image hall = new Image("/img/hall.png");
    Image wall = new Image("/img/wall.png");
    Image character = new Image("/img/char.png");
    Image cash = new Image("/img/cash2.png");
    Image enemy = new Image("/img/enemy.png");

    //region 3.2.1
    Image health = new Image("/img/11.png");

    //endregion
    //region 4.2.1
    Image coffee = new Image("/img/coffee.jpg");

    //endregion

    GridPane layout; // менеджер компоновки. по сути, это панель, на которую
    // определённым образом выкладываются различные элементы управления

    Stage stage; // ссылка на окно приложения
    Scene scene; // ссылка на клиентскую область окна

    Random r = new Random();

    int smileX = width - 3;
    int smileY = height - 3; // стартовая позиция игрового персонажика

    public void options(Stage primaryStage) {
        ////////////////////////////////////////////////////////////////////////
        /// настройки окна
        stage = primaryStage;
        //region 4.1
        stage.setTitle("500"); // установка текста в заголовке окна (energy in start)
        //endregion

        //region 3.1
        //stage.setTitle("100"); // установка текста в заголовке окна (health in start)
        //endregion

        ///region 2.1
        //stage.setTitle("0"); // установка текста в заголовке окна (count of medals in start game)
        //endregion


        stage.setResizable(false); // размеры окна нельзя будет изменить
        stage.getIcons().add(character); // иконка приложения
        ////////////////////////////////////////////////////////////////////////
        /// настройки панели элементов
        layout = new GridPane(); // элементы будут выкладываться в виде сетки
        layout.setPadding(new Insets(5, 5, 5, 5)); // отступы панели от клиентской части окна
        layout.setStyle("-fx-background-color: rgb(92, 118, 137);"); // фон панели
        // layout.setGridLinesVisible(true); // сделать видимыми границы сетки
        /// жуткая процедура установки количества строк и столбцов панели:
        for (int i = 0; i < height; i++) {
            RowConstraints rowConst = new RowConstraints();
            rowConst.setPercentHeight(100.0 / height);
            layout.getRowConstraints().add(rowConst);
        }
        for (int i = 0; i < width; i++) {
            ColumnConstraints colConst = new ColumnConstraints();
            colConst.setPercentWidth(80.0 / width);          // остовляем место для отрисовки
            layout.getColumnConstraints().add(colConst);
        }
        ////////////////////////////////////////////////////////////////////////
        /// настройка клиентской области окна: элементы кладём на панель, панель -
        // на клиентскую область, клиентскую область - привязываем к окну
        scene = new Scene(layout, 16 * width, 16 * height); // 16 px - размер
        // одной ячейки лабиринта по ширине и по высоте
        stage.setScene(scene);

        ////////////////////////////////////////////////////////////////////////
        // здесь (возможно) будут другие общие настройки
    }

    public void generateMaze() {
        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {

                maze[y][x] = GameObject.HALL; // изначально, лабиринт пустой

                // в 1 случае из 5 - ставим стену
                if (r.nextInt(5) == 0) {
                    maze[y][x] = GameObject.WALL;
                }

                // в 1 случае из 250 - кладём денежку
                if (r.nextInt(250) == 0) {
                    maze[y][x] = GameObject.CASH;
                }

                // в 1 случае из 500 - кладём аптечку
                if (r.nextInt(500) == 0) {
                    maze[y][x] = GameObject.HEALTH;
                }

                // в 1 случае из 500 - кладём кофе
                if (r.nextInt(500) == 0) {
                    maze[y][x] = GameObject.COFFEE;
                }

                // в 1 случае из 250 - размещаем врага
                if (r.nextInt(250) == 0) {
                    maze[y][x] = GameObject.ENEMY;
                }

                // стены по периметру обязательны
                if (y == 0 || x == 0 || y == height - 1 | x == width - 1) {
                    maze[y][x] = GameObject.WALL;
                }

                // наш персонажик
                if (x == smileX && y == smileY) {
                    maze[y][x] = GameObject.CHAR;
                }

                // есть выход, и соседняя ячейка справа всегда свободна
                if (x == smileX + 1 && y == smileY || x == width - 1 && y == height - 3) {
                    maze[y][x] = GameObject.HALL;
                }

            }
        }

    }

    public void showMaze() {

        Image current;

        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {

                if (maze[y][x] == GameObject.HALL) {
                    current = hall;
                } else if (maze[y][x] == GameObject.WALL) {
                    current = wall;
                } else if (maze[y][x] == GameObject.CHAR) {
                    current = character;
                } else if (maze[y][x] == GameObject.CASH) {
                    current = cash;
                }else if (maze[y][x] == GameObject.HEALTH) {
                    current = health;
                }else if (maze[y][x] == GameObject.COFFEE) {
                        current = coffee;
                } else/* if (maze[y][x] == GameObject.ENEMY)*/ {
                    current = enemy;
                }

                images[y][x] = new ImageView(current);
                layout.add(images[y][x], x, y);
                //GridPane.setHalignment(imgView, HPos.CENTER);

            }
        }

        stage.show();
    }

    public void clearCell(int x, int y) {
        maze[y][x] = GameObject.HALL; // делаем пустую ячейку по указанной позиции
        layout.getChildren().remove(images[y][x]);

        // region 4.3
        if(isSaveImage){
            images[y][x] = new ImageView(coffee);
            isSaveImage = false;
        }
        //endregion
        images[y][x] = new ImageView(hall);
        layout.add(images[y][x], x, y);
    }

    public void setSmile(int x, int y) {

        //region 2.2

       if(maze[y][x] == GameObject.CASH){

           // показ в Title пока комент
           //int medals = Integer.parseInt(stage.getTitle());  // Вытаскиваем кол-во медалий
           //medals++;
          // String.valueOf(medals);
           //stage.setTitle(String.valueOf(medals));             // Ложим обратно с  medals++
           setModelCount(getModelCount() + 1);   // собрал медаль
           if(!isLastMedal())
                                            // Если все съели вызов окна выигрыша
               dialog = new MyDialog( new Alert(Alert.AlertType.INFORMATION), "победа - медали собраны!!! ",
                       "ты собрал " +  getModelCount() + " медалей ", true);
        }
        //endregion

        //region 3
        if(maze[y][x] == GameObject.ENEMY) {
            ////// показ в Title Жизни
            //region 3.4  пока отключин
            //int health = Integer.parseInt(stage.getTitle());  // Вытаскиваем кол-во жизни
            //health -= 25;
            //if(health == 0) {
            //   gameFalseDialog("игра заканчивается поражением" );
            //} else {
            //   stage.setTitle(String.valueOf(health));       // Ложим обратно с  health - 25
            //}
            //endregion

            // проверка есть ли еще монстры

            //region 6.1.1
            if(!thereAreSurvivors()){
                dialog = new MyDialog( new Alert(Alert.AlertType.INFORMATION), "победа - враги уничтожены!!! ",
                        "ты собрал " +  getModelCount() + " медалей ", true);
            }
            //endregion

        }
        //endregion

        //region 3.2.2
        if(maze[y][x] == GameObject.HEALTH) {
            ////// показ в Title Жизни
            int health = Integer.parseInt(stage.getTitle());  // Вытаскиваем кол-во жизни
            if(health != 100)
            {
                health += 25;
            }
                stage.setTitle(String.valueOf(health));       // Ложим обратно с  health + 25
        }
        //endregion

        //region 4.1.2  Каждое перемещение персонажа тратит energy--

            int energy = Integer.parseInt(stage.getTitle());  // Вытаскиваем кол-во energy
            energy--;

            if(energy == 0)                                 // паражения
            {
                dialog = new MyDialog( new Alert(Alert.AlertType.ERROR), "поражение – закончилась энергия!!! ",
                        "ты собрал " +  getModelCount() + " медалей ", false);
            }
            stage.setTitle(String.valueOf(energy));       // Ложим обратно с  energy--
        //endregion

        // region 4.2.2
        if(maze[y][x] == GameObject.COFFEE){
            if(countFromCoffee == 0) {

                int pacEnergy = Integer.parseInt(stage.getTitle());  // Вытаскиваем кол-во energy
                pacEnergy += 25;

                isEatCoffee = true;                                  // Сьели кофе запустили счет ходов
                countFromCoffee = 10;                                // Изночально 10 ходов нельзя есть кофе

                stage.setTitle(String.valueOf(pacEnergy));           // Ложим обратно с  energy + 25
            }
            else {
                isSaveImage = true;                                   // попытка сьесть кофедо 10 шагов
                // нужно вернуть фото обратно
            }
        }
        //endregion

        maze[y][x] = GameObject.CHAR;
        layout.getChildren().remove(images[y][x]);
        images[y][x] = new ImageView(character);
        layout.add(images[y][x], x, y);
    }

    public void gameProcess() {
        scene.setOnKeyPressed((KeyEvent t) -> {

            clearCell(smileX, smileY);

            if (t.getCode() == KeyCode.RIGHT && maze[smileY][smileX + 1] != GameObject.WALL) {
                smileX++;
            } else if (t.getCode() == KeyCode.LEFT && smileX > 0 && maze[smileY][smileX - 1] != GameObject.WALL) {
                smileX--;
            } else if (t.getCode() == KeyCode.UP && smileY > 0 && maze[smileY - 1][smileX] != GameObject.WALL) {
                smileY--;
            }else if (t.getCode() == KeyCode.DOWN && smileY > 0 && maze[smileY + 1][smileX] != GameObject.WALL) {
                smileY++;
            }else if (t.getCode() == KeyCode.SHIFT) {
                // region 5
                swordStrike();
                killCash();
                // endregion
            }
            if(isEatCoffee) {
                countFromCoffee--;
                if(countFromCoffee == 0)
                    isEatCoffee = false;
            }

            setSmile(smileX, smileY);
            //region 1.1
            if (smileX == width - 1 && smileY == height - 3) {
                dialog = dialog = new MyDialog( new Alert(Alert.AlertType.INFORMATION), "победа - найден выход!!! ",
                        "ты собрал " +  getModelCount() + " медалей ", true);

                //openDialog("победа - найден выход");
            }
            //endregion
        });
    }

    private boolean isLastMedal() {
        boolean flag = false;

        for (int i = 0; i < maze.length ; i++) {
            for (int j = 0; j < maze[i].length; j++) {         // Пробежали посмотрели есть ли еще медали
                if(maze[i][j] == GameObject.CASH){
                    flag = true;                           // Вышли если не последнии
                    break;
                }
                if(flag)
                    break;
            }
        }
        return flag;
    }

    private void swordStrike(){
            // смотрю колько энергии
        int pacEnergy = Integer.parseInt(stage.getTitle());  // Вытаскиваем кол-во energy
        if(pacEnergy > 20)
            pacEnergy -= 10;

        stage.setTitle(String.valueOf(pacEnergy));   //вернули обратно
    }

    private void killCash(){
        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 3; j++) {
                if(maze[smileY - 1 + i][smileX - 1 + j] == GameObject.ENEMY){

                    // проверка есть ли еще монстры
                    //region 6.1.2
                    if(!thereAreSurvivors()){
                        dialog = new MyDialog( new Alert(Alert.AlertType.INFORMATION), "победа - враги уничтожены!!!! ",
                                "ты собрал " +  getModelCount() + " медалей ", true);
                    }
                    //endregion

                    // clear point
                    maze[smileY - 1 + i][smileX - 1 + j] = GameObject.HALL;
                    layout.getChildren().remove(images[smileY - 1 + i][smileX - 1 + j]);
                    images[smileY - 1 + i][smileX - 1 + j] = new ImageView(hall);
                    layout.add(images[smileY - 1 + i][smileX - 1 + j], smileX - 1 + j, smileX - 1 + j);
                }
            }
        }
    }

    private boolean thereAreSurvivors(){
        boolean isHave = false;

        for (int y = 0; y < width; y++) {
            for (int x = 0; x < height; x++) {
                if(maze[y][x] == GameObject.ENEMY){
                    isHave = true;
                    break;
                }
            }
            if(isHave)
                break;
        }

        return isHave;
    }

}

// ===============================================================================================================================

// download javaFX:
// step 1) https://www.oracle.com/java/technologies/javase/javafx-overview.html
// step 2) https://wiki.openjdk.java.net/display/OpenJFX/Main
// step 3) https://openjfx.io/
// step 4) https://gluonhq.com/products/javafx/

// download scene builder:
// https://www.oracle.com/java/technologies/javase/javafxscenebuilder-info.html

// icons:
// https://v1.iconsearch.ru/search/?q=heart&x=0&y=0

// javaFX dialogs:
// https://code.makery.ch/blog/javafx-dialogs-official/

// ===============================================================================================================================

// https://metanit.com/java/javafx/1.8.php
// File > Project Structure > Libraries > + (add lib)

// VM Options: Run > Edit Configurations > Modify Options
// --module-path "C:\1\javafx-sdk-15.0.1\lib" --add-modules javafx.controls,javafx.fxml,javafx.media