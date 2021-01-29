using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Model
{
    public class ClientRepository
    {
        private static ObservableCollection<Client> _clients;

        public static ObservableCollection<Client> AllClients
        {
            get
            {
                // Ленивая инициализация
                if (_clients == null)
                    _clients = GenerateClientRepository();
                return _clients;
            }
        }

        private static ObservableCollection<Client> GenerateClientRepository()
        {
            //
            // Здесь в реальности мы, например, лезем в БД или каким-нибудь
            // другим способом получаем доступ к полезным нам данным
            //

            var clients = new ObservableCollection<Client>
            {
                new Client("Artem", "Krol"),
                new Client("Nik", "Krol"),
                new Client("Inga", "Greenberg")
            };
            return clients;
        }

    }
}
