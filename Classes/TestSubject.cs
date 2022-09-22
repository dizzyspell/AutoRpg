using ConsoleApp1.Actions;

namespace ConsoleApp1.Classes;

internal class TestSubject : Class, IClass
{
    public override string Name => "Test Subject";

    public ActionSet ActionSet => new ActionSet(
        new Actions.Basic.Whack(),
        new Actions.Support.Heal(),
        new Actions.Defend.Block(),
        new Actions.Attack.BigBonk()
    );
}
