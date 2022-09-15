using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Personalities
{
    internal class Kind : Personality, IPersonality
    {
        internal Kind() : base("Kind", 5, 3, 1, 1) { }
    }
}
