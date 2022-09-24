using AutoRPG.Core.Actions;

namespace AutoRPG.Core.Classes;

public class Cat : Class, IClass
{
    public override string Name => "Cat";

    public ActionSet ActionSet => new ActionSet(
        new Actions.Basic.Meow(),
        new Actions.Support.Purr(),
        new Actions.Defend.DownpourOfFluff(),
        new Actions.Attack.HuntersGift()
    );
}
