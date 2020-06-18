using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.Model
{
    public class MySaleContextInitialiazer : CreateDatabaseIfNotExists<MySaleContext>
    {
        protected override void Seed(MySaleContext context)
        {
            var buyers = new Buyer[]
            {
                new Buyer {FirstName = "Artem",LastName = "Krol"},
                new Buyer {FirstName = "Yosef",LastName = "Abramov"},
                new Buyer {FirstName = "Petia",LastName = "Ivanov"},
                new Buyer {FirstName = "Sasha",LastName = "Petrov"},
                new Buyer {FirstName = "Dasha",LastName = "Petrova"}
            };
            Array.ForEach(buyers, buyer => context.Buyers.Add(buyer));

            var sellers = new Seller[]
            {
                new Seller {FirstName = "Veronika",LastName = "Andreeva"},
                new Seller {FirstName = "Pasha",LastName = "Egorov"},
                new Seller {FirstName = "Olia",LastName = "Ivanova"}
            };
            Array.ForEach(sellers, seller => context.Sellers.Add(seller));

            var sales = new Sale[]
                 {
                new Sale {SaleAmount = 320,SaleDate = new DateTime(2018, 02, 23), Buyer = buyers[0], Seller = sellers[2]},
                new Sale {SaleAmount = 220,SaleDate = new DateTime(2018, 02, 24), Buyer = buyers[1], Seller = sellers[2]},
                new Sale {SaleAmount = 180,SaleDate = new DateTime(2018, 01, 23), Buyer = buyers[2], Seller = sellers[0]},
                new Sale {SaleAmount = 5000,SaleDate = new DateTime(2018, 02, 25), Buyer = buyers[3], Seller = sellers[1]},
                new Sale {SaleAmount = 1258,SaleDate = new DateTime(2018, 02, 26), Buyer = buyers[4], Seller = sellers[1]},
                new Sale {SaleAmount = 4100,SaleDate = new DateTime(2018, 03, 08), Buyer = buyers[2], Seller = sellers[0]}
                 };
            Array.ForEach(sales, sale => context.Sales.Add(sale));
        }
    }
}
