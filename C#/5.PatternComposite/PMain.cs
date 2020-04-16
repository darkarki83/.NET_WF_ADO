using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternComposite
{
    class PMain
    {
        static void Main(string[] args)
        {
            ///////////////////Reception////////////////////////////
            ///



            //ClassComponent computer = new create_comp("computer", 1).create_computer();
            //computer.Print();
            ClassComponent room = new Create_room("first room", 1).Create_one_room();
            room.Print();



            object[] arr1 =  { true, 2, "hi", 13.7m };
            for (int i = 0; i < arr1.Length; i++)
            {
                Console.WriteLine("object  {0} : type {1}", arr1[i], arr1[i].GetType());
            }
           
























            /* ClassComponent Reception = new Composite("\t\t\tПРИЕМНАЯ");
             ClassComponent BookTable = new Composite("Журнальный столик.");
             ClassComponent Book = new Primitive("\t\tЖурнал Компьютерный мир.");
             ClassComponent Bed = new Primitive("Мягкий Деван.");
             ClassComponent TableSecretary = new Composite("Стол Секретаря.");
             ClassComponent PK = new Composite("\t\tКомпьютер Секретаря.");
             ClassComponent BigHDD = new Primitive("\t\t\tЖесткий Диск С большым обьемом Памяти.");
             ClassComponent OfficeInstrument = new Primitive("\t\tОфиссный Инструментарий.");
             ClassComponent Culer = new Primitive("Кулер с Теплой и Холодной водой.\n\n\n");

             Reception.Add(BookTable);
             for (int i = 0; i < 5; i++)
             {
                 BookTable.Add(Book);
             }
             Reception.Add(Bed);
             PK.Add(BigHDD);
             TableSecretary.Add(PK);
             TableSecretary.Add(OfficeInstrument);
             Reception.Add(TableSecretary);
             Reception.Add(Culer);
             Reception.Print();




             ///////////////////////////////ClassRomm1////////////////////
             ClassComponent ClassRoom1 = new Composite("\t\t\tАУДИТОРИЯ-№1");
             ClassComponent Table = new Primitive("\t\tСтолы для Аудитории-№1.");
             ClassComponent Desk = new Primitive("Доска для Аудитории-№1.");
             ClassComponent TeacherTable = new Composite("Стол Учителя");
             ClassComponent TeacherPK = new Primitive("\t\tУчительский Компьютер");
             ClassComponent PicturesofGreatMathematicians = new Primitive("Картины Великих математиков\n\n\n");
             for (int i = 0; i < 10; i++)
             {
                 ClassRoom1.Add(Table);
             }
             ClassRoom1.Add(Desk);
             TeacherTable.Add(TeacherPK);
             ClassRoom1.Add(TeacherTable);
             ClassRoom1.Add(PicturesofGreatMathematicians);
             ClassRoom1.Print();




             ////////////////ClassRoom2//////////////
             ClassComponent ClassRoom2 =new Composite("\t\t\tАУДИТОРИЯ-№2");
             ClassComponent Table2 = new Composite("Столы для Аудитории-№2.");
             ClassComponent BlackTable = new Primitive("\t\tЦвет Чорный.");
             ClassComponent CircleTable = new Primitive("\t\tСтолы Стоят по кругу.\n");
             ClassComponent Desk2 = new Primitive("Доска для Аудитории-№2");
             ClassComponent Bed2 = new Primitive("Мягкий Деван.\n\n\n");
             Table2.Add(BlackTable);
             Table2.Add(CircleTable);
             for (int i = 0; i < 10; i++)
             {
                 ClassRoom2.Add(Table2);

             }
             ClassRoom2.Add(Desk2);
             ClassRoom2.Add(Bed2);
             ClassRoom2.Print();




             /////////////////////////PKRoom////////////////////
             ClassComponent PKRoom = new Composite("\t\t\tПК-АУДИТОРИЯ");
             ClassComponent PKTable = new Composite("Столы для ПК.");
             ClassComponent PKInTable = new Composite("\t\tПК на Каждом столе.");
             ClassComponent CPU = new Primitive("\t\t\tПроцессор 2.2ГРц.");
             ClassComponent HDD = new Primitive("\t\t\tВинчестер на 80 ГБ.");
             ClassComponent OZU = new Primitive("\t\t\tОперативная память 1024МБ.");
             ClassComponent Rozetka = new Primitive("\t\tРозетка возле каждого стола.");
             ClassComponent PKDesk = new Composite("Доска для Компьютерной комнаты.");
             ClassComponent Marker = new Primitive("\t\t\tНабор Маркеров.\n\n\n");
             PKInTable.Add(CPU);
             PKInTable.Add(HDD);
             PKInTable.Add(OZU);
             PKTable.Add(PKInTable);
             PKTable.Add(Rozetka);
             for (int i = 0; i < 5; i++)
             {
                 PKRoom.Add(PKTable);
             }
             PKDesk.Add(Marker);
             PKRoom.Add(PKDesk);
             PKRoom.Print();





             //////////////////Canteen/////////////////
             ClassComponent Canteen = new Composite("\t\t\tСтоловая");
             ClassComponent CoffeAutomat = new Primitive("Кофейный Автомат.");
             ClassComponent Table3 = new Composite("Столовый Стол.");
             ClassComponent ChairCanteen = new Primitive("\t\t\tСтулья для столовой.");
             ClassComponent Fridge = new Primitive("Холодильник.");
             ClassComponent Washer = new Primitive("Умывальник.");
             for (int i = 0; i < 4; i++)
             {
                 Table3.Add(ChairCanteen);
             }

             Canteen.Add(CoffeAutomat);
             Canteen.Add(Table3);
             Canteen.Add(Fridge);
             Canteen.Add(Washer);
             Canteen.Print();*/

        }
    }
}
