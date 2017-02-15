using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CompilerLab.DesktopApplication.Infrastructure
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        private ViewModelLocator _viewModelLocator;
        public State State { get; set; }
        public ViewModelLocator ViewModelLocator
        {
            get
            {
                return _viewModelLocator ??
                       (_viewModelLocator =
                           (ViewModelLocator)App.Current.Resources["ViewModelLocator"]);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
