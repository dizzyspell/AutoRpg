using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Personalities
{
    internal class Stoic : Personality, IPersonality
    {
        internal Stoic() : base("Stoic", 5, 1, 3, 1) { }
    }
}
