using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace HWLinq2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Colors> colors = new List<Colors>();
            colors.Add(new Colors(1, "White"));
            colors.Add(new Colors(2, "Red"));
            colors.Add(new Colors(3, "Green"));
            colors.Add(new Colors(4, "Blue"));
           
            List<Types> types = new List<Types>();
            types.Add(new Types(1, "Tarred"));
            types.Add(new Types(2, "Ornamental"));
            types.Add(new Types(3, "Semiprecious"));

            List<Stones> stones = new List<Stones>();
            stones.Add(new Stones(1, "Diamond", true, "about one", 1, 1));
            stones.Add(new Stones(2, "Ruby", true, "about two", 2, 1));
            stones.Add(new Stones(3, "Spinel", false, "about tree", 2, 2));
            stones.Add(new Stones(4, "Granite", false, "about four", 2, 3));
            stones.Add(new Stones(5, "Tile", false, "about five", 3, 2));
            stones.Add(new Stones(6, "Emerald", true, "about six", 3, 1));
            stones.Add(new Stones(7, "Lazurit", false, "about seven", 4, 1));
            stones.Add(new Stones(8, "Topaz", true, "about eight", 4, 1));
            stones.Add(new Stones(9, "Lapis Lazuli", false, "about nine", 4, 3));
            stones.Add(new Stones(10, "Turquoise", false, "about ten", 4, 3));

            Console.WriteLine($"Write Color Bones");
            string str = Console.ReadLine().ToLower();

            /*XDocument xdoc = new XDocument();
            // создаем первый элемент
            XElement iphone6 = new XElement("phone");
            // создаем атрибут
            XAttribute iphoneNameAttr = new XAttribute("name", "iPhone 6");
            XElement iphoneCompanyElem = new XElement("company", "Apple");
            XElement iphonePriceElem = new XElement("price", "40000");
            // добавляем атрибут и элементы в первый элемент
            iphone6.Add(iphoneNameAttr);
            iphone6.Add(iphoneCompanyElem);
            iphone6.Add(iphonePriceElem);

            // создаем второй элемент
            XElement galaxys5 = new XElement("phone");
            XAttribute galaxysNameAttr = new XAttribute("name", "Samsung Galaxy S5");
            XElement galaxysCompanyElem = new XElement("company", "Samsung");
            XElement galaxysPriceElem = new XElement("price", "33000");
            galaxys5.Add(galaxysNameAttr);
            galaxys5.Add(galaxysCompanyElem);
            galaxys5.Add(galaxysPriceElem);
            // создаем корневой элемент
            XElement phones = new XElement("phones");
            // добавляем в корневой элемент
            phones.Add(iphone6);
            phones.Add(galaxys5);
            // добавляем корневой элемент в документ
            xdoc.Add(phones);
            //сохраняем документ
            xdoc.Save("phones.xml");*/

            var bone =
                          from c in colors
                          from t in types
                          from s in stones
                          where t.Id == s.TypesFK && s.ColorsFK == c.Id && c.Color.ToLower() == str
                          select new
                          {
                              s.Name,
                              s.Transparency,
                              s.About,
                              Type = t.Type,
                              Color = c.Color
                          };
            
            Console.WriteLine("Bones");
            bone.All(b => { Console.WriteLine($"Name : {b.Name} \nTransparency : {b.Transparency} \nAbout : {b.About} \nType : {b.Type} \nColor : {b.Color} \n"); return true; });
            Console.WriteLine();
            Console.WriteLine($"{bone}");

            //string str = "Vasiia";

            //var en =
            //              from w in worker
            //              where w.FirstName == str
            //              select new
            //              {
            //                  ID  = w.Id,
            //                  SDate = w.StartDate,
            //                  EDate = w.EndDate
            //              };

            //Console.WriteLine("workDay:");
            //en.All(w => { Console.WriteLine($"Start Date :{w.SDate} , End Date :{w.EDate}"); return true; });
            //Console.WriteLine();
            //Console.WriteLine($"{en}");

            //var weekD =
            //            from o in ofWeek
            //            from d in workerDay
            //            where d.WorkerFK == en.First().ID && d.DaysOfWeekFK == o.Id
            //            select new
            //            {
            //                Days = o.Day
            //            };


            //Console.WriteLine("weekD:");
            //weekD.All(w => { Console.WriteLine($"Start Date :{w.Days}"); return true; });
            //Console.WriteLine();
            //Console.WriteLine($"{weekD}");

            //List<DateTime> dateTimes = new List<DateTime>();
            //for (DateTime i = en.First().SDate; i < en.First().EDate;)
            //{

            //    dateTimes.Add(i);
            //    i = i.AddDays(1);
            //}

            //Console.WriteLine("workDay:");
            //dateTimes.All(w => { Console.WriteLine($"Date :{w}"); return true; });
            //Console.WriteLine();
            //Console.WriteLine($"{dateTimes}");

            //var theDays =
            //                 from t in dateTimes
            //                 from w in weekD
            //                     //from  workerDay in d
            //                   where (int)t.DayOfWeek == (w.Days - 1)
            //                 select t;



            // Console.WriteLine("Day:");
            //theDays.All(w => { Console.WriteLine($"{w}"); return true; });
            // Console.WriteLine();
            // Console.WriteLine($"{theDays}");
        }
    }
}
