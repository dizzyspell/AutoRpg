using ConsoleApp1.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Classes
{
    internal class Cultist : Class, IClass
    {
        public override string Name => "Cultist";

        public ActionSet ActionSet => new ActionSet(
            new Actions.Basic.Poke(),
            new Actions.Support.SoulShare(),
            new Actions.Defend.FleshShield(),
            new Actions.Attack.HugOfDeception()
        );
    }
}
