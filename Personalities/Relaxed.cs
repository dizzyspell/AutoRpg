using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Personalities
{
    internal class Relaxed : Personality, IPersonality
    {
        internal Relaxed() : base("Relaxed", 7, 1, 1, 1) { }
    }
}
