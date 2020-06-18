using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.Model
{
    public class Model : IModel
    {
        private MySaleContext myContext;
        public MySaleContext Context { get => myContext; set => myContext = value; }
        public Model(MySaleContext context)
        {
            Context = context;
            Context.Buyers.Load();
            Context.Sellers.Load();
            Context.Sales.Load();
        }

        public void ModelSample()
        {
            // Подгружаем из БД не только сами объекты, но и
            // вложенные коллекции дочерних для них объектов
            //context.Authors.Include(a => a.Books).ToList();
            //context.Presses.Include(p => p.Books).ToList();
           // Context.Buyers.bu
           // Context.Sellers.Load();
            //Context.Sales.Load();


            //Context.Buyers.Include(b => b.Sales).ToList();
        }
        
    }
}
