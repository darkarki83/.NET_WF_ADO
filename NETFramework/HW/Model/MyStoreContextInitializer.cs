using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.Model
{
    public class MyStoreContextInitializer : CreateDatabaseIfNotExists<MyStoreContext>
    {
        protected override void Seed(MyStoreContext context)
        {
            var manufacturers = new Manufacturer[]
            {
                new Manufacturer { Id = 1, Name = "Roda" },
                new Manufacturer { Id = 2, Name = "Termomont" },
                new Manufacturer { Id = 3, Name = "Honeywell" },
                new Manufacturer { Id = 4, Name = "Spirotech" }
            };
            foreach (var manufacturer in manufacturers)
                context.Manufacturers.Add(manufacturer);
            // Или можно вот так:
            // Array.ForEach(authors, author => context.Authors.Add(author));

            var clients = new Client[]
            {
                new Client { Id = 1, Name = "Ник лтд", Adrress = "Одесса, ул.Небесной сотни 15", Bonus = 15 },
                new Client { Id = 2, Name = "ТелеКом", Adrress = "Одесса, ул.Решельевская 3", Bonus = 7.5 },
                new Client { Id = 3, Name = "УкрЭнерго", Adrress = "Херсон, ул.Бориспольская 7", Bonus = 22.5 },
                new Client { Id = 4, Name = "АрмТек", Adrress = "Киев, ул.Черноморская 6", Bonus = 15 },
                new Client { Id = 5, Name = "Энергия сервис", Adrress = "Чернигов, ул.Гончая 51", Bonus = 10 },
                new Client { Id = 6, Name = "Овк комплект", Adrress = "Киев, ул.Институтская 16", Bonus = 13 },
               
            };
            foreach (var client in clients)
                context.Clients.Add(client);
            // Или можно вот так:
            // Array.ForEach(presses, press => context.Presses.Add(press));

            var parts = new Part[]
            {
                new Part { Id = 1, Name = "Электрический котел Roda Storm SL 8 - 7,5 кВт", Cost = 499, Status = false, ManufacturerFk = manufacturers[0].Id },
                new Part { Id = 2, Name = "Электрический котел Roda Storm SL 18 - 18 кВт", Cost = 527, Status = false, ManufacturerFk = manufacturers[0].Id },
                new Part { Id = 3, Name = "Электрический котел Roda Storm SL 15 - 15 кВт", Cost = 527, Status = false, ManufacturerFk = manufacturers[0].Id },
                new Part { Id = 4, Name = "Твердотопливный котёл Termomont ТКК3-25 кВт", Cost = 1453, Status = true, ManufacturerFk = manufacturers[1].Id },
                new Part { Id = 5, Name = "Твердотопливный котёл Termomont ТКU3-20 кВт", Cost = 1514, Status = true, ManufacturerFk = manufacturers[1].Id },
                new Part { Id = 6, Name = "Твердотопливный котёл Termomont ТКК3-30 кВт", Cost = 1574, Status = true, ManufacturerFk = manufacturers[1].Id },
                new Part { Id = 7, Name = "Твердотопливный котёл Termomont ТКU3-25 кВт", Cost = 1635, Status = true, ManufacturerFk = manufacturers[1].Id },
                new Part { Id = 8, Name = "Пеллетный котел Termomont TOBY 12В 12 кВт", Cost = 3269, Status = false, ManufacturerFk = manufacturers[1].Id },
                new Part { Id = 9, Name = "Пеллетный котел Termomont TOBY 12Н 12 кВт", Cost = 3451, Status = false, ManufacturerFk = manufacturers[1].Id },
                new Part { Id = 10, Name = "Пеллетная горелка Termomont Biotermec 50 (10-50 кВт)", Cost = 1639, Status = false, ManufacturerFk = manufacturers[1].Id },
                new Part { Id = 11, Name = "Пеллетная горелка Termomont Biotermec 100 (50-100 кВт)", Cost = 2795, Status = true, ManufacturerFk = manufacturers[1].Id },
                new Part { Id = 12, Name = "Пеллетная горелка Termomont Agrotermec 50 кВт", Cost = 3255, Status = false, ManufacturerFk = manufacturers[1].Id },
                new Part { Id = 13, Name = "Топливная емкость MAFA MINI-300", Cost = 605, Status = true, ManufacturerFk = manufacturers[1].Id },
                new Part { Id = 14, Name = "Топливная емкость MAFA MIDI-730", Cost = 1090, Status = false, ManufacturerFk = manufacturers[1].Id },
                new Part { Id = 15, Name = "Автоматический воздухоотводчик Honeywell E121-3/8A", Cost = 9, Status = true, ManufacturerFk = manufacturers[2].Id },
                new Part { Id = 16, Name = "Автоматический воздухоотводчик Honeywell E121-1/2A", Cost = 10, Status = true, ManufacturerFk = manufacturers[2].Id },
                new Part { Id = 17, Name = "Автоматический воздухоотводчик Spirovent Spirotop AAV AB050", Cost = 76, Status = false, ManufacturerFk = manufacturers[3].Id },
                new Part { Id = 18, Name = "Автоматический воздухоотводчик Spirotop AAV AB050/008", Cost = 115, Status = false, ManufacturerFk = manufacturers[3].Id },
                new Part { Id = 19, Name = "Автоматический воздухоотводчик Spirotop AAV AB050/002", Cost = 115, Status = false, ManufacturerFk = manufacturers[3].Id },
                new Part { Id = 20, Name = "Сепаратор воздуха SpiroVent Air AA075 3/4", Cost = 134, Status = false, ManufacturerFk = manufacturers[3].Id },
                new Part { Id = 21, Name = "Сепаратор воздуха Spirovent Air AA100 1", Cost = 142, Status = false, ManufacturerFk = manufacturers[3].Id },
                new Part { Id = 22, Name = "Гидравлическая стрелка SpiroCross DN50 (под приварку - сталь)", Cost = 1526, Status = true, ManufacturerFk = manufacturers[3].Id },
                new Part { Id = 23, Name = "Гидравлическая стрелка SpiroCross DN50 (фланец - сталь)", Cost = 1777, Status = true, ManufacturerFk = manufacturers[3].Id },
                new Part { Id = 24, Name = "Гидравлическая стрелка SpiroCross DN65 (под приварку - сталь)", Cost = 1780, Status = true, ManufacturerFk = manufacturers[3].Id },
                new Part { Id = 25, Name = "Гидравлическая стрелка SpiroCross DN65 (фланец - сталь)", Cost = 2062, Status = true, ManufacturerFk = manufacturers[3].Id}
            };
            foreach (var part in parts)
                context.Parts.Add(part);
            // Или можно вот так:
            // Array.ForEach(books, book => context.Books.Add(book));

            var orders = new Order[]
            { 
                new Order { Id = 1, OrderData = null, ClientFk = clients[0].Id },
                new Order { Id = 2, OrderData = null, ClientFk = clients[1].Id },
                new Order { Id = 3, OrderData = null, ClientFk = clients[1].Id },
                new Order { Id = 4, OrderData = null, ClientFk = clients[2].Id },
                new Order { Id = 5, OrderData = null, ClientFk = clients[3].Id },
                new Order { Id = 6, OrderData = null, ClientFk = clients[4].Id },
                new Order { Id = 7, OrderData = null, ClientFk = clients[4].Id },
                new Order { Id = 8, OrderData = null, ClientFk = clients[0].Id}
            };
            foreach (var order in orders)
                context.Orders.Add(order);

            var partsInOrders = new PartsInOrder[]
            {
                new PartsInOrder { Id = 1, PartFk = parts[0].Id, OrderFk = orders[0].Id, Count = 1, TotalCost = 1 * parts[0].Cost },
                new PartsInOrder { Id = 2, PartFk = parts[0].Id, OrderFk = orders[5].Id, Count = 2, TotalCost = 2 * parts[0].Cost },
                new PartsInOrder { Id = 3, PartFk = parts[2].Id, OrderFk = orders[0].Id, Count = 1, TotalCost = 1 * parts[2].Cost },
                new PartsInOrder { Id = 4, PartFk = parts[4].Id, OrderFk = orders[1].Id, Count = 3, TotalCost = 3 * parts[4].Cost },
                new PartsInOrder { Id = 5, PartFk = parts[4].Id, OrderFk = orders[1].Id, Count = 1, TotalCost = 1 * parts[4].Cost },
                new PartsInOrder { Id = 6, PartFk = parts[5].Id, OrderFk = orders[2].Id, Count = 1, TotalCost = 1 * parts[5].Cost },
                new PartsInOrder { Id = 7, PartFk = parts[6].Id, OrderFk = orders[6].Id, Count = 2, TotalCost = 2 * parts[6].Cost },
                new PartsInOrder { Id = 8, PartFk = parts[8].Id, OrderFk = orders[3].Id, Count = 1, TotalCost = 1 * parts[8].Cost },
                new PartsInOrder { Id = 9, PartFk = parts[9].Id, OrderFk = orders[2].Id, Count = 6, TotalCost = 6 * parts[9].Cost },
                new PartsInOrder { Id = 10, PartFk = parts[10].Id, OrderFk = orders[1].Id, Count = 2, TotalCost = 2 * parts[10].Cost },
                new PartsInOrder { Id = 11, PartFk = parts[12].Id, OrderFk = orders[4].Id, Count = 5, TotalCost = 5 * parts[12].Cost },
                new PartsInOrder { Id = 12, PartFk = parts[15].Id, OrderFk = orders[6].Id, Count = 1, TotalCost = 1 * parts[15].Cost },
                new PartsInOrder { Id = 13, PartFk = parts[15].Id, OrderFk = orders[7].Id, Count = 2, TotalCost = 2 * parts[15].Cost },
                new PartsInOrder { Id = 14, PartFk = parts[15].Id, OrderFk = orders[2].Id, Count = 1, TotalCost = 1 * parts[15].Cost },
                new PartsInOrder { Id = 15, PartFk = parts[17].Id, OrderFk = orders[5].Id, Count = 3, TotalCost = 3 * parts[17].Cost },
                new PartsInOrder { Id = 16, PartFk = parts[19].Id, OrderFk = orders[4].Id, Count = 5, TotalCost = 5 * parts[19].Cost },
                new PartsInOrder { Id = 17, PartFk = parts[20].Id, OrderFk = orders[1].Id, Count = 4, TotalCost = 4 * parts[20].Cost },
                new PartsInOrder { Id = 18, PartFk = parts[21].Id, OrderFk = orders[3].Id, Count = 2, TotalCost = 2 * parts[21].Cost },
                new PartsInOrder { Id = 19, PartFk = parts[22].Id, OrderFk = orders[5].Id, Count = 1, TotalCost = 1 * parts[22].Cost },
                new PartsInOrder { Id = 20, PartFk = parts[22].Id, OrderFk = orders[4].Id, Count = 1, TotalCost = 1 * parts[22].Cost },
                new PartsInOrder { Id = 21, PartFk = parts[23].Id, OrderFk = orders[2].Id, Count = 3, TotalCost = 3 * parts[23].Cost },
                new PartsInOrder { Id = 22, PartFk = parts[24].Id, OrderFk = orders[3].Id, Count = 4, TotalCost = 4 * parts[24].Cost }
            };
            foreach (var partsInOrder in partsInOrders)
                context.PartsInOrders.Add(partsInOrder);

            base.Seed(context);
        }
    }
}
