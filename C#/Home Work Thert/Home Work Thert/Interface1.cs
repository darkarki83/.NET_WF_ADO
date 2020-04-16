using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work_Thert
{
    interface Product
    {
        void AddProduct(All_Detals One);
        void Print();
        
    }

   /* interface HouseholdChemicals
    {
        int ShelfLife { get; set; }
        void CheckShelfLife();
    }

    */
    interface ShortLivedCommodities
    {
        void CheckShelfLife();
    }

    interface ExciseProduct 
    {
        //decimal Tax { get; set; }
        decimal BayTax(All_Detals One);
    }

    interface FlammableProduct
    {
        void CheckTempStorage();
    }

    interface BeatingProduct
    {
        decimal CheckCostOfLoss();
    }
}
