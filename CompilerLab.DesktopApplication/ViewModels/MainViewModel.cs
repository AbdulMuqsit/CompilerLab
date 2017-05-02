using CompilerLab.DesktopApplication.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerLab.DesktopApplication.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            NavigateToPFNViewCommand = new RelayCommand(obj => ChildViewModel = ViewModelLocator?.PFNViewModel, (obj) => !(ChildViewModel is PFNViewModel));
            NavigateToRegexExamplesViewCommand = new RelayCommand(obj => ChildViewModel = ViewModelLocator?.RegexExamplesViewModel, (obj) => !(ChildViewModel is RegexExamplesViewModel));
            NavigateToRegexExamplesViewCommand = new RelayCommand(obj => ChildViewModel = ViewModelLocator?.JavaRegexViewModel, (obj) => !(ChildViewModel is JavaRegexViewModel));
            NavigateToDFAViewCommand = new RelayCommand(obj => ChildViewModel = ViewModelLocator?.DFAViewModel, (obj) => !(ChildViewModel is DFAViewModel));
        }


        private ViewModelBase _childViewModel;

        public ViewModelBase ChildViewModel
        {
            get { return _childViewModel; }
            set
            {
                if (_childViewModel == value)
                {
                    return;
                }
                _childViewModel = value;
                OnPropertyChanged();
            }
        }


        #region commands
        public RelayCommand NavigateToPFNViewCommand { get; set; }
        public RelayCommand NavigateToRegexExamplesViewCommand { get; set; }
        public RelayCommand NavigateToJavaRegexViewCommand { get; set; }
        public RelayCommand NavigateToDFAViewCommand { get; set; }
        #endregion
    }
}
