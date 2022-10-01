using AutoRPG.Core.Actions;
using AutoRPG.Core.Actions.Attack;
using AutoRPG.Core.Actions.Basic;
using AutoRPG.Core.Actions.Defend;
using AutoRPG.Core.Actions.Support;

namespace AutoRPG.Core.Classes
{
    public class TestSubject : Class, IClass
    {
        public override string Name => "Test Subject";

        public ActionSet ActionSet => new ActionSet(
            new Whack(),
            new Heal(),
            new Block(),
            new BigBonk()
        );
    }
}