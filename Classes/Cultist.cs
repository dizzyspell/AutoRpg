using ConsoleApp1.Actions;

namespace ConsoleApp1.Classes;

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
