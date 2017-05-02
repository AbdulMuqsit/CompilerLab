using CompilerLab.DesktopApplication.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CompilerLab.DesktopApplication.ViewModels
{
    public class JavaRegexViewModel : ViewModelBase
    {
        private string _variableInput;
        private bool _isValidVariable;
        private bool _isValidFloatDigit;
        private string _floatDigitInput;
        private string _floatLengthInput;
        private string _keywordsInput;
        private bool _isValidFloatLength;
        private bool _isValidKeyword;
        private string _dateInput;
        private bool _isValidDateInput;
        private string _registrationNumberInput;
        private bool _isValidRegistrationNumberInput;
        private bool _isValidEmail;
        private string _email;

        public string FloatLengthInput
        {
            get { return _floatLengthInput; }
            set
            {
                if (_floatLengthInput == value)
                {
                    return;
                }
                _floatLengthInput = value.Trim();
                IsValidFloatLength = Regex.IsMatch(FloatLengthInput, @"^(\d+)(.?)(\d*)$") && FloatLengthInput.Length <= 10;

                OnPropertyChanged();
            }
        }

        public string KeywordsInput
        {
            get { return _keywordsInput; }
            set
            {
                if (_keywordsInput == value)
                {
                    return;
                }
                _keywordsInput = value.Trim();
                IsValidKeyword = Regex.IsMatch(KeywordsInput, "^((int)|(float)|(char)|(double))$");

                OnPropertyChanged();
            }
        }
        public string VariableInput
        {
            get { return _variableInput; }
            set
            {
                if (_variableInput == value)
                {
                    return;
                }
                _variableInput = value.Trim();
                IsValidVariable = Regex.IsMatch(VariableInput, "^[_a-zA-Z]([_a-zA-Z]*[0-9]*)*$");

                OnPropertyChanged();
            }
        }
        public bool IsValidVariable
        {
            get { return _isValidVariable; }
            set
            {
                if (_isValidVariable == value)
                {
                    return;
                }
                _isValidVariable = value;
                OnPropertyChanged();
            }
        }
        public bool IsValidFloatLength
        {
            get { return _isValidFloatLength; }
            set
            {
                if (_isValidFloatLength == value)
                {
                    return;
                }
                _isValidFloatLength = value;

                OnPropertyChanged();
            }
        }
        public bool IsValidKeyword
        {
            get { return _isValidKeyword; }
            set
            {
                if (_isValidKeyword == value)
                {
                    return;
                }
                _isValidKeyword = value;
                OnPropertyChanged();
            }
        }
        public string FloatDigitInput
        {
            get { return _floatDigitInput; }
            set
            {
                if (_floatDigitInput == value)
                {
                    return;
                }
                _floatDigitInput = value.Trim();
                IsValidFloatDigit = Regex.IsMatch(FloatDigitInput, @"^(\d+).?(\d*)$");

                OnPropertyChanged();
            }
        }
        public bool IsValidFloatDigit
        {
            get { return _isValidFloatDigit; }
            set
            {
                if (_isValidFloatDigit == value)
                {
                    return;
                }
                _isValidFloatDigit = value;
                OnPropertyChanged();
            }
        }







        public string DateInput
        {
            get { return _dateInput; }
            set
            {
                if (_dateInput == value)
                {
                    return;
                }
                _dateInput = value.Trim();
                IsValidDateInput = Regex.IsMatch(_dateInput, @"^((0[1-9])|([1-2][0-9])|(3[0-1]))-((0[1-9])|(1[0-2]))-([1-2]\d\d\d)$");
                OnPropertyChanged();
            }
        }
        public bool IsValidDateInput
        {
            get { return _isValidDateInput; }
            set
            {
                if (_isValidDateInput == value)
                {
                    return;
                }
                _isValidDateInput = value;
                OnPropertyChanged();
            }
        }




        public string RegistrationNumberInput
        {
            get { return _registrationNumberInput; }
            set
            {
                if (_registrationNumberInput == value)
                {
                    return;
                }
                _registrationNumberInput = value.Trim();
                IsValidRegistrationNumberInput = Regex.IsMatch(_registrationNumberInput, @"^((((F|f)(A|a))|((S|s)(P|p)))\d\d)-(bcs|btn)-((00[1-9])|([1-9]\d\d)|(\d[1-9]\d))$");
                OnPropertyChanged();
            }
        }
        public bool IsValidRegistrationNumberInput
        {
            get { return _isValidRegistrationNumberInput; }
            set
            {
                if (_isValidRegistrationNumberInput == value)
                {
                    return;
                }
                _isValidRegistrationNumberInput = value;
                OnPropertyChanged();
            }
        }


        public string Email
        {
            get { return _email; }
            set
            {
                if (_email == value)
                {
                    return;
                }
                _email = value.Trim();
                IsValidEmail = Regex.IsMatch(_email, @"^([a-zA-Z])+(.|_|[a-zA-Z]|\d)*@([A-Za-z]{3,}).com$");
                OnPropertyChanged();
            }
        }
        public bool IsValidEmail
        {
            get { return _isValidEmail; }
            set
            {
                if (_isValidEmail == value)
                {
                    return;
                }
                _isValidEmail = value;
                OnPropertyChanged();
            }
        }



    }
}
