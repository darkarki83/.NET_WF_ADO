using MVVM2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM2.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        // Текущий клиент
        public ClientModel Client { get; set; }
        
        public MainWindowViewModel()
        {
            Client = new ClientModel { FirstName = "Art", LastName = "Kr" };
        }

        public string ClientFirstName
        {
            get => Client.FirstName;
            set
            {
                if (Client.FirstName != value)
                {
                    Client.FirstName = value;
                    OnPropertyChanged("ClientFirstName");
                }
            }
        }

        public string ClientLastName
        {
            get => Client.LastName;
            set
            {
                if (Client.LastName != value)
                {
                    Client.LastName = value;
                    OnPropertyChanged("ClientLastName");
                }
            }
        }

    }
}
