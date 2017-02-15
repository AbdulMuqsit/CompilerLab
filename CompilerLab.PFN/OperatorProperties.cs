using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerLab.PFN
{
    public class OperatorProperties
    {
        public List<char> OperatorsList { get; }
        public Dictionary<char, int[]> Precedence { get; } = new Dictionary<char, int[]> { { '+', new int[2] { 1, 1 } }, { '-', new int[2] { 1, 1 } }, { '*', new int[2] { 2, 2 } }, { '/', new int[2] { 2, 2 } }, { '^', new int[2] { 3, 3 } }, { '(', new int[2] { 4, 0 } }, { ')', new int[2] { 4, 0 } } };
        public OperatorProperties()
        {
            OperatorsList = Precedence.Keys.ToList();
        }
    }
}
