using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerLab.PFN
{
    public class PFNEngine
    {

        public async Task<string> ConvertToPFNString(string expression, Dictionary<char, int> precedence)
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
                         if (operandStack.Count == 0 || precedence[operandStack.Peek()] <= precedence[currentCharacter])
                         {
                             operandStack.Push(currentCharacter);
                         }
                         else
                         {
                             pfnStringBuilder.Append(operandStack.Pop());
                         }
                     }
                 }
                 while (operandStack.Count > 0)
                 {
                     pfnStringBuilder.Append(operandStack.Pop());

                 }
                 return pfnStringBuilder.ToString();
             });
        }
        public async Task<int> EvaluatePFNString(string PFNString)
        {
            var PFNArray = PFNString.ToCharArray();
            for (int i = 0; i < PFNString.Count(); i++)
            {
                if (Operators.OperatorsList.Contains(PFNArray[i + 2]))
                {
                    EvaluateExpression(PFNArray[i], PFNArray[i + 1], PFNArray[i + 2]);
                }
            }
            return 0;

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
