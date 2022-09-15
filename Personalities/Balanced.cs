using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Personalities
{
    internal class Balanced : Personality, IPersonality
    {
        internal Balanced() : base("Balanced", 5, 1, 2, 2) { }
    }
}
