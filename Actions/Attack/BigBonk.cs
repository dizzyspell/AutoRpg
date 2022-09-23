using ConsoleApp1.Contexts;

namespace ConsoleApp1.Actions.Attack;

internal class BigBonk : IAction
{
    public string Name => "Big Bonk";

    public string Description => "Does lots of damage";

    public ActionType Type => ActionType.Attack;

    public ActionContext Execute(IContext aContext, ITargetable aTarget)
    {
        int fAdjustedDamage = aTarget.ApplyDamage(2);

        return new ActionContext(aContext, this, aTarget, fAdjustedDamage);
    }

    public IEnumerable<ITargetable> ValidTargets(IContext aContext)
    {
        return aContext.Enemies.Where(a => a.IsAlive).Cast<ITargetable>();
    }
}
