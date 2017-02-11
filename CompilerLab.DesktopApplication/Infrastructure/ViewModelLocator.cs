using CompilerLab.DesktopApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerLab.DesktopApplication.Infrastructure
{
    public class ViewModelLocator
    {
        public MainViewModel MainViewModel { get; } = new MainViewModel();
        public PFNViewModel PFNViewModel { get; } = new PFNViewModel();

    }
}
