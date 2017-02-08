using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerLab.PFN
{
    public class PFNEngine
    {
        public static string ConvertToPNF(string expression, Dictionary<char, int> precedence)
        {
            Stack<char> operandStack = new Stack<char>();
            StringBuilder pnfString = new StringBuilder();

            var expressionArray = expression.ToCharArray();
            for (int i = 0; i < expressionArray.Count(); i++)
            {
                if (Char.IsDigit(expressionArray[i]))
                {
                    pnfString.Append(expressionArray[i]);
                }
            }
            return pnfString.ToString();
        }
    }
}
