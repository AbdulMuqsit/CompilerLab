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
                             while (operandStack.Count != 0 && currentCharacter != '(' && currentCharacter != ')' && precedence[operandStack.Peek()][1] >= precedence[currentCharacter][0])
                             {
                                 pfnStringBuilder.Append(operandStack.Pop());

                             }
                             operandStack.Push(currentCharacter);
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
                Stack<int> EvaluationStack = new Stack<int>();
                int firsOperand, seconOperand;
                if (PFNString.Count() == 1)
                {
                    return Int32.Parse(PFNString);
                }


                var PFNArray = PFNString.ToCharArray();
                for (int i = 0; i < PFNArray.Count(); i++)
                {
                    if (OperatorProperties.OperatorsList.Contains(PFNArray[i]))
                    {
                        seconOperand = EvaluationStack.Pop();
                        firsOperand = EvaluationStack.Pop();
                        if (i < PFNArray.Count() - 1 && PFNArray[i] == '-' && PFNArray[i + 1] == '-')
                        {
                            EvaluationStack.Push(EvaluateExpression(-firsOperand, seconOperand, PFNArray[i]));

                        }
                        else
                        {
                            EvaluationStack.Push(EvaluateExpression(firsOperand, seconOperand, PFNArray[i]));

                        }
                    }
                    else
                    {
                        EvaluationStack.Push((int)Char.GetNumericValue(PFNArray[i]));
                    }
                }
                return EvaluationStack.Pop();
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
                while (input.IndexOf("(-") >= 0)
                {
                    input = input.Insert(input.IndexOf("(-") + 1, "0");
                }

                while (input.IndexOf("((") >= 0)
                {
                    input = input.Insert(input.IndexOf("((") + 1, "*");
                }
                for (int i = 0; i < 10; i++)
                {
                    while (input.IndexOf($"{i}(") >= 0)
                    {
                        input = input.Insert(input.IndexOf($"{i}(") + 1, "*");
                    }

                }

                return input;
            });
        }

        private int EvaluateExpression(int firstOperand, int secondOperand, char @operator)
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
                return x - Math.Abs(y);
            }
            else if (@operator == '^')
            {
                return (int)Math.Pow(x, y);
            }
            else
            {
                throw new NotImplementedException($"The operator {@operator} is not implemented");
            }
        }
    }
}
