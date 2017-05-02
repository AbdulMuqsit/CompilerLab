using CompilerLab.DesktopApplication.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerLab.DesktopApplication.ViewModels
{
    public class DFAViewModel : ViewModelBase
    {
        public string _xyzzDFA;
        public string XYZZDFAInput
        {
            get
            {
                return _xyzzDFA;
            }
            set
            {
                _xyzzDFA = value;
                OnPropertyChanged();
                ExecuteXYZZDFA();
            }
        }

        private bool _xyzzDFAExecuted;

        public bool XYZZDFAExecuted
        {
            get { return _xyzzDFAExecuted; }
            set
            {
                _xyzzDFAExecuted = value;
                OnPropertyChanged();
            }
        }

        private string _errorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; }
        }




        private string _EvenABInput;

        public string EvenABInput
        {
            get { return _EvenABInput; }
            set
            {
                _EvenABInput = value;
                ExecuteEvenABDFA();
                OnPropertyChanged();
            }
        }

        private bool _evenABExecuted;

        public bool EvenABExecuted
        {
            get { return _evenABExecuted; }
            set
            {
                _evenABExecuted = value;
                OnPropertyChanged();
            }
        }
        private bool _variableDFAExecuted;

        public bool VariableDFAExecuted
        {
            get { return _variableDFAExecuted; }
            set
            {
                _variableDFAExecuted = value;
                OnPropertyChanged();
            }
        }


        private string _variableDFAInput;

        public string VariableDFAInput
        {
            get { return _variableDFAInput; }
            set
            {
                _variableDFAInput = value;
                ExecuteJavaVariableDFA();
                OnPropertyChanged();
            }
        }

        private void ExecuteXYZZDFA()
        {
            XYZZDFAExecuted = false;
            string initialState = "q0";
            List<string> finalStates = new List<string>() { "q4" };
            string currentState = initialState;
            Dictionary<string, Dictionary<string, string>> DFA = new Dictionary<string, Dictionary<string, string>>()
            {
                { "q0", new Dictionary<string, string>{ { "x", "q1" }, { "y", "q5" }, { "z", "q5" } } },
                { "q1", new Dictionary<string, string>{ { "y", "q2" }, { "z", "q5" }, { "x", "q5" } } },
                { "q2", new Dictionary<string, string>{ { "z", "q3" }, { "x", "q5" }, { "y", "q5" } } },
                { "q3", new Dictionary<string, string>{ { "z", "q4" }, { "x", "q5" }, { "y", "q5" } } },
                { "q4", new Dictionary<string, string>{ { "x", "q5" }, { "y", "q5" }, { "z", "q5" } } },
                { "q5", new Dictionary<string, string>{ { "x", "q5" }, { "y", "q5" }, { "z", "q5" } } },

            };

            XYZZDFAExecuted = ExecuteDFA(XYZZDFAInput, initialState, finalStates, DFA);
        }

        private void ExecuteEvenABDFA()
        {

            XYZZDFAExecuted = false;
            string initialState = "q0";
            List<string> finalStates = new List<string>() { "q0" };
            string currentState = initialState;
            Dictionary<string, Dictionary<string, string>> dfa = new Dictionary<string, Dictionary<string, string>>()
            {
                { "q0", new Dictionary<string, string>{ { "a", "q1" }, { "b", "q2" } } },
                { "q1", new Dictionary<string, string>{ { "a", "q0" }, { "b", "q3" } } },
                { "q2", new Dictionary<string, string>{ { "a", "q3" }, { "b", "q0" } } },
                { "q3", new Dictionary<string, string>{ { "a", "q2" }, { "b", "q1" } } },

            };
            EvenABExecuted = ExecuteDFA(EvenABInput, initialState, finalStates, dfa);
        }

        private void ExecuteJavaVariableDFA()
        {

            VariableDFAExecuted = false;
            string initialState = "q0";
            List<string> finalStates = new List<string>() { "q1" };
            string currentState = initialState;
            Dictionary<string, Dictionary<string, string>> dfa = new Dictionary<string, Dictionary<string, string>>()
            {



                { "q0", new Dictionary<string, string>{ { "a", "q1" }, { "b", "q1" }, { "c", "q1" }, { "d", "q1" }, { "e", "q1" }, { "f", "q1" }, { "g", "q1" }, { "h", "q1" }, { "i", "q1" }, { "j", "q1" }, { "k", "q1" }, { "l", "q1" }, { "m", "q1" }, { "n", "q1" }, { "o", "q1" }, { "p", "q1" }, { "q", "q1" }, { "r", "q1" }, { "s", "q1" }, { "t", "q1" }, { "u", "q1" }, { "v", "q1" }, { "w", "q1" }, { "x", "q1" }, { "y", "q1" }, { "z", "q1" }, { "0", "q2" }, { "1", "q2" }, { "3", "q2" }, { "4", "q2" }, { "5", "q2" }, { "7", "q2" }, { "8", "q2" }, { "9", "q2" }, { "_", "q1" } }
                },
                { "q1", new Dictionary<string, string>{ { "a", "q1" }, { "b", "q1" }, { "c", "q1" }, { "d", "q1" }, { "e", "q1" }, { "f", "q1" }, { "g", "q1" }, { "h", "q1" }, { "i", "q1" }, { "j", "q1" }, { "k", "q1" }, { "l", "q1" }, { "m", "q1" }, { "n", "q1" }, { "o", "q1" }, { "p", "q1" }, { "q", "q1" }, { "r", "q1" }, { "s", "q1" }, { "t", "q1" }, { "u", "q1" }, { "v", "q1" }, { "w", "q1" }, { "x", "q1" }, { "y", "q1" }, { "z", "q1" }, { "0", "q1" }, { "1", "q2" }, { "3", "q1" }, { "4", "q1" }, { "5", "q1" }, { "7", "q1" }, { "8", "q1" }, { "9", "q1" }, { "_", "q1" } }
                },
                { "q2", new Dictionary<string, string>{ { "a", "q1" }, { "b", "q1" }, { "c", "q1" }, { "d", "q1" }, { "e", "q1" }, { "f", "q1" }, { "g", "q1" }, { "h", "q1" }, { "i", "q2" }, { "j", "q2" }, { "k", "q2" }, { "l", "q2" }, { "m", "q2" }, { "n", "q2" }, { "o", "q2" }, { "p", "q2" }, { "q", "q2" }, { "r", "q2" }, { "s", "q2" }, { "t", "q2" }, { "u", "q2" }, { "v", "q2" }, { "w", "q2" }, { "x", "q2" }, { "y", "q2" }, { "z", "q2" }, { "0", "q2" }, { "1", "q2" }, { "3", "q2" }, { "4", "q2" }, { "5", "q2" }, { "7", "q2" }, { "8", "q2" }, { "9", "q2" }, { "_", "q2" } }
                }



            };
            VariableDFAExecuted = ExecuteDFA(VariableDFAInput, initialState, finalStates, dfa);
        }

        private bool ExecuteDFA(string input, string initialState, List<string> finalStates, Dictionary<string, Dictionary<string, string>> dfa)
        {
            string currentState = initialState;

            foreach (var v in input.Trim())
            {
                try
                {
                    currentState = dfa[currentState][v.ToString()];
                }
                catch (Exception)
                {
                    ErrorMessage = "Invalid Input";
                    return false;

                }

            }
            if (finalStates.Contains(currentState))
            {
                return true;
            }
            return false;
        }





    }
}
