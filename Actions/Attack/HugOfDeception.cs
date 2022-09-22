using ConsoleApp1.Contexts;

namespace ConsoleApp1.Actions.Attack;

internal class HugOfDeception : IAction
{
    public string Name => "Hug of Deception";

    public string Description => "A BIG hug... which turns an enemy's defense against them!";

    public ActionType Type => ActionType.Attack;

    public ActionContext Execute(IContext aContext)
    {
        ICharacter fTarget = aContext.Enemies.Where(a => a.IsAlive).OrderByDescending(a => a.DefensePoints).First();
        int fAdjustedValue = -fTarget.ApplyDefense(-2);
        fTarget.ApplyDamage(fAdjustedValue);

        return new ActionContext(aContext, this, fTarget, fAdjustedValue);
    }
}
