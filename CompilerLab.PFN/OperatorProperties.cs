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
        public Dictionary<char, int> Precedence { get; } = new Dictionary<char, int> { { '+', 1 }, { '-', 1 }, { '*', 2 }, { '/', 2 }, { '^', 3 } };
        public OperatorProperties()
        {
            OperatorsList = Precedence.Keys.ToList();
        }
    }
}
