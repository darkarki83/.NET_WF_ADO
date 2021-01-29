using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged, IDisposable
    {
        // Защищенный конструктор
        protected BaseViewModel()
        {
        }

        #region INotifyPropertyChanged implementation (механизм уведомления об изменении свойств модели)

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion


        #region IDisposable implementation (полиморфная реализация)

        // Собственно, реализация Dispose() из IDisposable
        public void Dispose()
        {
            // На самом деле всю работу по освобождению ресурсов
            // делегируем защищенному виртуальному методу OnDispose()
            OnDispose();
        }

        #endregion

        // При необходимости освобождения ресурсов, реальную работу
        // будем делать здесь, переопределяя этот метод в потомке(ах)
        protected virtual void OnDispose()
        {
        }

    }
}
