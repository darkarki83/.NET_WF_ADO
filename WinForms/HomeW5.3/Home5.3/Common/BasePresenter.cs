﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home5._3.Common
{
    public abstract class BasePresenter<T> : IPresenter<T> where T : IView
    {
        public T View { get; set; }
    }
}
