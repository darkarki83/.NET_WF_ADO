using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6._2.Common
{
    public abstract class BasePresenter<T> : IPresenter<T> where T:IView
    {
        public T View { get; set; }
    }
}
