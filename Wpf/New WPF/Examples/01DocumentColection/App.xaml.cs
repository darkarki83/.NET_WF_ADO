
using DocumentColection.Source;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DocumentColection
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private List<Document1> documents = new List<Document1>();
        public List<Document1> Documents
        {
            get => documents;
            set => documents = value;
        }
    }
}
