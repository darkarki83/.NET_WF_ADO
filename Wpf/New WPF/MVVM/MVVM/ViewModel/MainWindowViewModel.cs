using MVVM.Infrastructure;
using MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        // Текущий клиент (сам тип клиента берется из модели)
        private Client _currentClient;
        public Client CurrentClient
        {
            get
            {
                // Ленивая инициализация
                if (_currentClient == null)
                    _currentClient = new Client();
                return _currentClient;
            }
            set
            {
                _currentClient = value;
                OnPropertyChanged("CurrentClient");
            }
        }

        // Все клиенты (сам тип клиента для коллекции так же берется из модели).
        // В этой программе это свойство — readonly. Поэтому механизм уведомления
        // представления о ее изменении здесь не нужен.
        private ObservableCollection<Client> _clients;
        public ObservableCollection<Client> Clients
        {
            get
            {
                // Ленивая инициализация
                if (_clients == null)
                    _clients = ClientRepository.AllClients;
                return _clients;
            }
        }


        //
        // Команда AddClient и ее привязка (execute и canExecute)
        //
        
        private RelayCommand _addClientCommand;
        public ICommand AddClientCommand
        {
            get
            {
                // Ленивая инициализация
                if (_addClientCommand == null)
                    _addClientCommand = new RelayCommand(ExecuteAddClientCommand, CanExecuteAddClientCommand);
                return _addClientCommand;
            }
        }

        // execute-привязка (добавляем нового клиента)
        public void ExecuteAddClientCommand(object parameter)
        {
            Clients.Add(CurrentClient);
            CurrentClient = null;
        }
        
        // canExecute-привязка (оба поля CurrentClient.FirstName и CurrentClient.LastName должны быть не пустые)
        public bool CanExecuteAddClientCommand(object parameter)
        {
            return !string.IsNullOrEmpty(CurrentClient.FirstName) && !string.IsNullOrEmpty(CurrentClient.LastName);
        }

        
        //
        // Полиморфная реализация паттерна Disposable
        //

        // Вызывается из Dispose() базового класса
        protected override void OnDispose()
        {
            Clients.Clear();
        }
    }
}
