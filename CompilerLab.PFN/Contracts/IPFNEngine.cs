using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerLab.PFN.Contracts
{
    public interface IPFNEngine
    {
        Task<string> ConvertToPFNString(string expression, Dictionary<char, int[]> precedence);
        Task<int> EvaluatePFNString(string PFNString);
        Task<string> Normalize(string input);

    }
}
