using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.Model
{
    // Class Order table in database MyStore 
    /*
     * Id
     * OrderData
     * ClientFk
     * 
     *   Колекция разных частей заказа 
     * ICollection<PartsInOrder> PartsInOrders 
     */
    public class Order
    {
            // Можно было не указывать потому, что так было бы по умолчания, благодаря соглашению о наименованиях EF
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public DataType? OrderData { get; set; }

        // Внешние ключи.
        // Задаем правила сопоставления классов модели с таблицами БД.

        public long? ClientFk { get; set; }
        [ForeignKey("ClientFk")]
        public virtual Client Client { get; set; }

         // Колекция разных частей заказа 
          
        public ICollection<PartsInOrder> PartsInOrders { get; set; }
    }
}
