using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Personalities
{
    internal class Unhinged : Personality, IPersonality
    {
        internal Unhinged() : base("Unhinged", 3, 1, 1, 1) { }
    }
}
