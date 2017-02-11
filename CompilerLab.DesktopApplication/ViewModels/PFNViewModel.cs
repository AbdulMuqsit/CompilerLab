using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompilerLab.DesktopApplication.Infrastructure;
using CompilerLab.PFN;
using Ninject;
using CompilerLab.PFN.Contracts;

namespace CompilerLab.DesktopApplication.ViewModels
{
    public class PFNViewModel : ViewModelBase
    {
        public RelayCommand EvaluateCommand { get; }
        private IPFNEngine PFNEngine { get; }
        private string intermediatePFNString;

        public string IntermediatePFNString
        {
            get { return intermediatePFNString; }
            set
            {
                if (intermediatePFNString == value)
                {
                    return;
                }
                intermediatePFNString = value;
                OnPropertyChanged();
            }
        }

        private string errorString;

        public string ErrorString
        {
            get { return errorString; }
            set
            {
                if (errorString == value)
                {
                    return;
                }
                errorString = value; OnPropertyChanged();
            }
        }

        private OperatorProperties OperatorProperties { get; }
        private string inputString;

        public string InputString
        {
            get { return inputString; }
            set
            {
                if (inputString == value)
                {
                    return;
                }
                inputString = value;
                OnPropertyChanged();
            }
        }
        public PFNViewModel(IPFNEngine pFNEngine, OperatorProperties operatorProperties)
        {
            PFNEngine = pFNEngine;
            OperatorProperties = operatorProperties;
            EvaluateCommand = new RelayCommand(ExecuteEvaluateCommand);
        }
        private async void ExecuteEvaluateCommand(object obj)
        {
            try
            {
                IntermediatePFNString = await PFNEngine.ConvertToPFNString(InputString, OperatorProperties.Precedence);

            }
            catch (System.Exception ex)
            {
                ErrorString = ex.Message;
            }
        }
    }
}

