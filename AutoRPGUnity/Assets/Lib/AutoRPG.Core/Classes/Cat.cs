using AutoRPG.Core.Actions;
using AutoRPG.Core.Actions.Attack;
using AutoRPG.Core.Actions.Basic;
using AutoRPG.Core.Actions.Defend;
using AutoRPG.Core.Actions.Support;

namespace AutoRPG.Core.Classes
{
    public class Cat : Class, IClass
    {
        public override string Name => "Cat";

        public ActionSet ActionSet => new ActionSet(
            new Meow(),
            new Purr(),
            new DownpourOfFluff(),
            new HuntersGift()
        );
    }
}