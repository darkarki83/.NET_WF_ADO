using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.Model
{
    public class MyLibraryContextInitializer : CreateDatabaseIfNotExists<MyLibraryContext>
    {
        protected override void Seed(MyLibraryContext context)
        {
            var authors = new Author[]
            {
                new Author { Id = 1, Name = "Братья Стругацкие" },
                new Author { Id = 2, Name = "Айзек Азимов" },
                new Author { Id = 3, Name = "Роналд Руел Толкиен" },
                new Author { Id = 4, Name = "Стивен Кинг" },
                new Author { Id = 5, Name = "Джордж Мартин" }
            };
            Array.ForEach(authors, author => context.Authors.Add(author));

            var presses = new Press[]
            {
                new Press { Id = 1, Name = "АСТ" },
                new Press { Id = 2, Name = "Эксмо" },
                new Press { Id = 3, Name = "Росмен" }
            };
            Array.ForEach(presses, press => context.Presses.Add(press));

            var books = new Book[]
            {
                new Book { Id = 1, Name = "Обитаемый остров", Author = authors[0], Pages = 500, Price = 129.55m, Press = presses[0] },
                new Book { Id = 2, Name = "Жук в муравейнике", Author = authors[0], Pages = 400, Price = 95.5m, Press = presses[0] },
                new Book { Id = 3, Name = "Волны гасят ветер", Author = authors[0], Pages = 300, Price = 90m, Press = presses[1] },
                new Book { Id = 4, Name = "Основание", Author = authors[1], Pages = 450, Price = 150m, Press = presses[1] },
                new Book { Id = 5, Name = "Я, робот", Author = authors[1], Pages = 250, Price = 85.99m, Press = presses[1] },
                new Book { Id = 6, Name = "Стальные пещеры", Author = authors[1], Pages = 500, Price = 99.99m, Press = presses[2] },
                new Book { Id = 7, Name = "Хоббит, или Туда и обратно", Author = authors[2], Pages = 150, Price = 79.99m, Press = presses[2] },
                new Book { Id = 8, Name = "Властелин колец", Author = authors[2], Pages = 2000, Price = 800m, Press = presses[0] }
            };

            Array.ForEach(books, book => context.Books.Add(book));

            base.Seed(context);
        }
    }
}
