using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeWPF.ViewModels
{
    class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(params string[] values)
        {
            if (PropertyChanged != null)
            {
                foreach (string value in values)
                    PropertyChanged(this, new PropertyChangedEventArgs(value));
            }
        }
    }
}
