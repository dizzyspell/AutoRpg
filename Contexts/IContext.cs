using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Contexts
{
    internal interface IContext
    {
        public ICharacter Self { get; set; }

        public Party Allies { get; set; }

        public Party Enemies { get; set; }
    }
}
