using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerLab.PFN
{
    public class PFNEngine
    {
        public static async Task<string> ConvertToPNF(string expression, Dictionary<char, int> precedence)
        {
            return await Task.Run(() =>
             {
                 Stack<char> operandStack = new Stack<char>();
                 StringBuilder pnfString = new StringBuilder();

                 var expressionArray = expression.ToCharArray();
                 for (int i = 0; i < expressionArray.Count(); i++)
                 {
                     var currentCharacter = expressionArray[i];
                     if (Char.IsDigit(currentCharacter))
                     {
                         pnfString.Append(currentCharacter);
                     }
                     else if (precedence.Keys.Contains(currentCharacter))
                     {
                         if (operandStack.Count == 0 || precedence[operandStack.Peek()] < precedence[currentCharacter])
                         {
                             operandStack.Push(currentCharacter);
                         }
                         else
                         {
                             pnfString.Append(operandStack.Pop());
                         }
                     }
                 }
                 return pnfString.ToString();
             });
        }
    }
}
