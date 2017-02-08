using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerLab.PFN
{
    class Operators
    {
        public static List<char> OperatorsList { get; }
        public static Dictionary<char, int> Precedence { get; } = new Dictionary<char, int> { { '+', 1 }, { '-', 1 }, { '*', 2 }, { '/', 2 }, { '^', 3 } };
        static Operators()
        {
            OperatorsList = Precedence.Keys.ToList();
        }
    }
}
