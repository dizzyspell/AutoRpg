using AutoRPG.Core.Contexts;

namespace AutoRPG.Core.Actions.Support;

public class Heal : IAction
{
    public string Name => "Heal";

    public string Description => "Heals some damage";

    public ActionType Type => ActionType.Support;

    public ActionContext Execute(IContext aContext, ITargetable aTarget)
    {
        int fAdjustedValue = aTarget.ApplyHeal(2);

        return new ActionContext(aContext, this, aTarget, fAdjustedValue);
    }

    public IEnumerable<ITargetable> ValidTargets(IContext aContext)
    {
        return new List<ITargetable> { aContext.Self };
    }
}
