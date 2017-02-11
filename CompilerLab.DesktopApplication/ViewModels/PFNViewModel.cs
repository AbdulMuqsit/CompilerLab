using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompilerLab.DesktopApplication.Infrastructure;

namespace CompilerLab.DesktopApplication.ViewModels
{
    public class PFNViewModel : ViewModelBase
    {
        public RelayCommand EvaluateCommand { get; } = new RelayCommand(ExecuteEvaluateCommand);

        public PFNViewModel()
        {
            
        }
        private static void ExecuteEvaluateCommand(object obj)
        {
            throw new NotImplementedException();
        }
    }
}

