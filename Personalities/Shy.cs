using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Personalities
{
    internal class Shy : Personality, IPersonality
    {
        internal Shy() : base("Shy", 5, 2, 2, 1) { }
    }
}
