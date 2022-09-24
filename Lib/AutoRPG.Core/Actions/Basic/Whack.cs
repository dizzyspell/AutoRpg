using AutoRPG.Core.Contexts;

namespace AutoRPG.Core.Actions.Basic;

public class Whack : IAction
{
    public string Name => "Whack";

    public string Description => "Does some damage";

    public ActionType Type => ActionType.Basic;

    public ActionContext Execute(IContext aContext, ITargetable aTarget)
    {
        int fAdjustedValue = aTarget.ApplyDamage(1);

        return new ActionContext(aContext, this, aTarget, fAdjustedValue);
    }

    public IEnumerable<ITargetable> ValidTargets(IContext aContext)
    {
        return aContext.Enemies.Where(a => a.IsAlive);
    }
}
