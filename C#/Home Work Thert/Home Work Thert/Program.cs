using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work_Thert
{
    class Program
    {
        static void Main(string[] args)
        {
            All_Detals first = new All_Detals();
            All_Detals second = new All_Detals();
            All_Detals thert = new All_Detals();

            first.NameProuct = "ochki";
            first.Cost = (decimal)12.25;
            first.Count = 35;
            first.ShelfLife = 900;

            second.NameProuct = "shapki";
            second.Cost = (decimal)45.2;
            second.Count = 20;
            second.ShelfLife = 900;

            thert.NameProuct = "sviter";
            thert.Cost = (decimal)125.29;
            thert.Count = 14;
            thert.ShelfLife = 900;

            Product aaa = new Vegitable();
            aaa.AddProduct(first);
            aaa.AddProduct(second);
            aaa.AddProduct(thert);
            aaa.Print();








        }
    }

    






}
