using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM2.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged, IDisposable
    {
        protected BaseViewModel()
        {
        }

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region IDisposable implementation

        public void Dispose()
        {
            OnDispose();
        }
        #endregion

        protected virtual void OnDispose()
        {
        }

    }
}