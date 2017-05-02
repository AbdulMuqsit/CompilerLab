using CompilerLab.DesktopApplication.ViewModels;
using CompilerLab.PFN;
using CompilerLab.PFN.Contracts;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerLab.DesktopApplication.Infrastructure
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            var container = ((App)App.Current).container;
            PFNViewModel = container.Get<PFNViewModel>();
            MainViewModel = container.Get<MainViewModel>();
            RegexExamplesViewModel = container.Get<RegexExamplesViewModel>();
            JavaRegexViewModel = container.Get<JavaRegexViewModel>();
            DFAViewModel = container.Get<DFAViewModel>();
            
        }
        public MainViewModel MainViewModel { get; }
        public PFNViewModel PFNViewModel { get; }
        public RegexExamplesViewModel RegexExamplesViewModel { get; }
        public JavaRegexViewModel JavaRegexViewModel { get; set; }
        public DFAViewModel DFAViewModel { get; internal set; }
    }
}
