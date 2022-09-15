using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Personalities
{
    internal class Angry : Personality, IPersonality
    {
        internal Angry() : base("Angry", 5, 1, 1, 3) { }
    }
}
