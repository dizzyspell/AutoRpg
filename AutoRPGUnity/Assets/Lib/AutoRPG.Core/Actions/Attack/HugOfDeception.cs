using AutoRPG.Core.Contexts;

namespace AutoRPG.Core.Actions.Attack;

public class HugOfDeception : IAction
{
    public string Name => "Hug of Deception";

    public string Description =>
        "A BIG hug... which turns an enemy's defense against them!";

    public ActionType Type => ActionType.Attack;

    public ActionContext Execute(IContext aContext, ITargetable aTarget)
    {
        int fAdjustedValue = -aTarget.ApplyDefense(-2);
        aTarget.ApplyDamage(fAdjustedValue);

        return new ActionContext(aContext, this, aTarget, fAdjustedValue);
    }

    public IEnumerable<ITargetable> ValidTargets(IContext aContext)
    {
        return aContext.Enemies.Where(a => a.IsAlive)
            .OrderByDescending(a => a.DefensePoints);
    }
}