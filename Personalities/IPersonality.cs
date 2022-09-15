using ConsoleApp1.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Personalities
{
    internal interface IPersonality
    {
        public string Name { get; }

        public IAction ChooseAction(ActionSet aActionSet);
    }
}
