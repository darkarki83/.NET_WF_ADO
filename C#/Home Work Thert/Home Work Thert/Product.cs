using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work_Thert
{
    struct All_Detals
    {
        public decimal Cost { get; set; }
        public string NameProuct { get; set; }
        public int CountP { get; set; }
        public int ShelfLife { get; set; }
        public decimal? Tax { get; set; }
        public int? TempStorage { get; set; }
        public int LossProduct { get; set; }


    }
    class HouseholdChemicals : Product
    {
        public List<All_Detals> HP;

       public HouseholdChemicals()
       {
            HP = new List<All_Detals>();
       }

        public void AddProduct(All_Detals One)
        {
            HP.Add(One);
        }

        public void Print()
        {
            foreach (var item in HP)
                Console.WriteLine("NameProuct {0} Cost {1} Count {2} ShelfLife{3} ", 
                    item.NameProuct, item.Cost, item.Count, item.ShelfLife);
        }
    }

    class Food : Product, ShortLivedCommodities
    {
        public List<All_Detals> HP;

        public Food()
        {
            HP = new List<All_Detals>();
        }

        public void AddProduct(All_Detals One)
        {
            HP.Add(One);
        }

        public void Print()
        {
            foreach (var item in HP)
                Console.WriteLine("NameProuct {0} Cost {1} Count {2} ShelfLife{3} ",
                    item.NameProuct, item.Cost, item.Count, item.ShelfLife);
        }

        public void CheckShelfLife()
        {
            for (int i = 0; i < HP.Count; i++)
            {
                if (HP[i].ShelfLife <= 1)
                    HP.RemoveAt(i);
            }
        }
    }

    class Vegitable : Product, ShortLivedCommodities
    {
        public List<All_Detals> HP;

        public Vegitable()
        {
            HP = new List<All_Detals>();
        }

        public void AddProduct(All_Detals One)
        {
            HP.Add(One);
        }

        public void Print()
        {
            foreach (var item in HP)
                Console.WriteLine("NameProuct {0} Cost {1} Count {2} ShelfLife {3} ",
                    item.NameProuct, item.Cost, item.Count, item.ShelfLife);
        }

        public void CheckShelfLife()
        {
            for (int i = 0; i < HP.Count; i++)
            {
                if (HP[i].ShelfLife <= 1)
                    HP.RemoveAt(i);
            }           
        }
    }

    class TabacAndAlcohol : Product, ExciseProduct
    {
        public List<All_Detals> HP;

        public TabacAndAlcohol()
        {
            HP = new List<All_Detals>();
        }

        public void AddProduct(All_Detals One)
        {
            HP.Add(One);
        }

        public void Print()
        {
            foreach (var item in HP)
                Console.WriteLine("NameProuct {0} Cost {1} Count {2} ShelfLife {3} ",
                    item.NameProuct, item.Cost, item.Count, item.ShelfLife);
        }
     
        public decimal BayTax(All_Detals One)
        {
            decimal tax = 0;
            if (One.Tax != null)
                tax = (decimal)(One.Cost * One.CountP * One.Tax);
            return tax;
        }
    }

    class Flammable : Product, FlammableProduct
    {
        public List<All_Detals> HP;

        public Flammable()
        {
            HP = new List<All_Detals>();
        }

        public void AddProduct(All_Detals One)
        {
            HP.Add(One);
        }

        public void Print()
        {
            foreach (var item in HP)
                Console.WriteLine("NameProuct {0} Cost {1} Count {2} ShelfLife {3} ",
                    item.NameProuct, item.Cost, item.CountP, item.ShelfLife);
        }

        public void CheckTempStorage()
        {
            for (int i = 0; i < HP.Count; i++)
            {
                if (HP[i].TempStorage > 20)
                {
                    HP.RemoveAt(i);
                }
            }
        }
    }

    class Beating : Product, BeatingProduct
    {
        public List<All_Detals> HP;

        public Beating()
        {
            HP = new List<All_Detals>();
        }

        public void AddProduct(All_Detals One)
        {
            HP.Add(One);
        }

        public void Print()
        {
            foreach (var item in HP)
                Console.WriteLine("NameProuct {0} Cost {1} Count {2} ShelfLife {3} ",
                    item.NameProuct, item.Cost, item.CountP, item.ShelfLife);
        }

        public decimal CheckCostOfLoss()
        {
            decimal tax = 0;

            for (int i = 0; i < HP.Count; i++)
            {
                if (HP[i].LossProduct > 0)
                {
                    HP[i].CountP -= HP[i].LossProduct;
                    tax += (decimal)(HP[i].Cost * HP[i].LossProduct);
                }
            }
            return tax;
        }
    }



}
