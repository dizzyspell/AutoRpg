using AutoRPG.Core.Actions;
using AutoRPG.Core.Actions.Attack;
using AutoRPG.Core.Actions.Basic;
using AutoRPG.Core.Actions.Defend;
using AutoRPG.Core.Actions.Support;

namespace AutoRPG.Core.Classes;

public class Cultist : Class, IClass
{
    public override string Name => "Cultist";

    public ActionSet ActionSet => new(
        new Poke(),
        new SoulShare(),
        new FleshShield(),
        new HugOfDeception()
    );
}