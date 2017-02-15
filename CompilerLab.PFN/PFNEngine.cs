using CompilerLab.PFN.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CompilerLab.PFN
{
    public class PFNEngine : IPFNEngine
    {
        private OperatorProperties OperatorProperties { get; } = new OperatorProperties();

        public async Task<string> ConvertToPFNString(string expression, Dictionary<char, int[]> precedence)
        {
            return await Task.Run(() =>
             {
                 Stack<char> operandStack = new Stack<char>();
                 StringBuilder pfnStringBuilder = new StringBuilder();

                 var expressionArray = expression.ToCharArray();
                 for (int i = 0; i < expressionArray.Count(); i++)
                 {
                     var currentCharacter = expressionArray[i];
                     if (Char.IsDigit(currentCharacter))
                     {
                         pfnStringBuilder.Append(currentCharacter);
                     }
                     else if (precedence.Keys.Contains(currentCharacter))
                     {

                         if (operandStack.Count == 0 || precedence[operandStack.Peek()][1] <= precedence[currentCharacter][0])
                         {
                             if (currentCharacter == ')')
                             {
                                 do
                                 {
                                     currentCharacter = operandStack.Pop();
                                     if (currentCharacter != '(' && currentCharacter != ')')
                                     {
                                         pfnStringBuilder.Append(currentCharacter);
                                     }
                                 } while (currentCharacter != '(' && operandStack.Count > 0);
                             }
                             else
                             {
                                 operandStack.Push(currentCharacter);
                             }
                         }
                         else
                         {
                             if (currentCharacter != '(' && currentCharacter != ')')
                             {
                                 pfnStringBuilder.Append(operandStack.Pop());
                             }

                         }
                     }
                 }
                 while (operandStack.Count > 0)
                 {
                     if (operandStack.Peek() != '(' && operandStack.Peek() != ')')
                     {
                         pfnStringBuilder.Append(operandStack.Pop());
                     }
                     else
                     {
                         operandStack.Pop();
                     }
                 }
                 return pfnStringBuilder.ToString();
             });
        }
        public async Task<int> EvaluatePFNString(string PFNString)
        {
            return await Task.Run(() =>
            {
                while (true)
                {

                }
                if (PFNString.Count() == 1)
                {
                    return Int32.Parse(PFNString);
                }
                var PFNArray = PFNString.ToCharArray();
                for (int i = 0; i < PFNString.Count() - 2; i++)
                {
                    if (OperatorProperties.OperatorsList.Contains(PFNArray[i + 2]))
                    {
                        EvaluateExpression(PFNArray[i], PFNArray[i + 1], PFNArray[i + 2]);
                    }
                }
                return 0;
            });

        }

        public async Task<string> Normalize(string input)
        {
            return await Task.Run(() =>
            {
                if (input.IndexOf("-") == 0)
                {
                    input = "0" + input;
                }
                while (input.IndexOf("(-") > 0)
                {
                    input = input.Insert(input.IndexOf("(-") + 1, "0");
                }
                for (int i = 0; i < 10; i++)
                {
                    while (input.IndexOf($"{i}(") > 0)
                    {
                        input = input.Insert(input.IndexOf($"{i}(") + 1, "*");
                    }

                }

                return input;
            });
        }

        private int EvaluateExpression(char firstOperand, char secondOperand, char @operator)
        {
            var x = Convert.ToInt32(firstOperand);
            var y = Convert.ToInt32(secondOperand);
            if (@operator == '*')
            {
                return x * y;
            }
            else if (@operator == '/')
            {
                return x / y;
            }
            else if (@operator == '+')
            {
                return x + y;
            }
            else if (@operator == '-')
            {
                return x - y;
            }
            else
            {
                throw new NotImplementedException($"The operator {@operator} is not implemented");
            }
        }
    }
}
