using System;

namespace Paging.Models
{
    public class Pages
    {
        // Всего объектов совокупно на всех страницах
        public int TotalItems { get; set; }

        // Размер страницы (максимальное количество объектов на странице)
        public int PageSize { get; set; }

        // Номер текущей страницы
        public int CurrentPage { get; set; }

        // Всего страниц
        public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / PageSize);
    }
}