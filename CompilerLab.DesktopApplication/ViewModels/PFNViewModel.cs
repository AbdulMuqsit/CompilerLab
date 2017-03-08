using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompilerLab.DesktopApplication.Infrastructure;
using CompilerLab.PFN;
using CompilerLab.PFN.Contracts;
using System.Text.RegularExpressions;
using System.Diagnostics;

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

        private string _normalizedInput;
        private string _evaluatedOuptup;

        public string NormalizedInput
        {
            get { return _normalizedInput; }
            set
            {
                if (_normalizedInput == value) return;
                _normalizedInput = value;
                OnPropertyChanged();
            }
        }
        public string EvaluatedOutput
        {
            get
            {
                return _evaluatedOuptup;
            }
            set
            {
                if (_evaluatedOuptup == value)
                {
                    return;
                }
                _evaluatedOuptup = value;
                OnPropertyChanged();
            }
        }

        public PFNViewModel(IPFNEngine pFNEngine, OperatorProperties operatorProperties)
        {
            PFNEngine = pFNEngine;
            OperatorProperties = operatorProperties;
            EvaluateCommand = new RelayCommand(ExecuteEvaluateCommand, ValidateInput);
        }


        private async void ExecuteEvaluateCommand(object obj)
        {
            try
            {
                NormalizedInput = await PFNEngine.Normalize(inputString);
                IntermediatePFNString = await PFNEngine.ConvertToPFNString(NormalizedInput, OperatorProperties.Precedence);
                EvaluatedOutput = (await PFNEngine.EvaluatePFNString(intermediatePFNString)).ToString();

            }
            catch (System.Exception ex)
            {
                ErrorString = ex.Message;
            }
        }


        private bool ValidateInput(object obj)
        {
            ErrorString = String.Empty;
            if (String.IsNullOrWhiteSpace(inputString))
            {
                return false;
            }

            if (Regex.IsMatch(inputString, @"^\s*\d+\s*([+-\/\^\*]\s*\d\s*)*$"))
            {
                ErrorString = String.Empty;
                State = State.Normal;
                return true;
            }
            ErrorString = "Invalid Input";
            return false;
        }

    }
}
