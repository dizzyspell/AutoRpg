using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Contexts;

namespace ConsoleApp1
{
    internal class Player
    {
        private readonly Party mrParty = new();
        private readonly List<ICharacter> mrReserve = new();

        internal Player(string aName)
        {
        }

        public Party Party => mrParty;

        public List<ICharacter> Reserve => mrReserve;

        public IContext Context => mrParty.First().Context;
    }
}
