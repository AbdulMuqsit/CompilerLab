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

            }
            catch (System.Exception ex)
            {
                ErrorString = ex.Message;
            }
        }


        private bool ValidateInput(object obj)
        {
            //ErrorString = String.Empty;

            //if (String.IsNullOrWhiteSpace(inputString))
            //{
            //    ErrorString = String.Empty;
            //    return false;
            //}
            //if (Regex.IsMatch(inputString, @"^\s*\d+\s*([+|-|\/|\^|*]\s*\d\s*)*$"))
            //{
            //    ErrorString = String.Empty;
            //    State = State.Normal;
            //    return true;
            //}
            //else
            //{
            //    State = State.Error;

            //    if (Regex.IsMatch(inputString, @"^.*\d\d.*$"))
            //    {
            //        ErrorString += "Only single digit integers are allowed for now!\n";
            //    }
            //    if (Regex.IsMatch(inputString, @"^.*[a-z|A-Z].*$"))
            //    {
            //        ErrorString += "Alphabets are not allowed!\n";
            //    }
            //    if (Regex.IsMatch(inputString, @"^.*[+|-|/|\^|*][+|-|\/|\^|*].*$"))
            //    {
            //        ErrorString += "Consecutive operators are not allowed!\n";
            //    }
            //    if (Regex.IsMatch(inputString, @"[^\/\*\^a-zA-Z0-9-+\s]"))
            //    {
            //        ErrorString += "Special characters are not allowed\n";
            //    }
            //}
            //return false;
            return true;
        }

    }
}
