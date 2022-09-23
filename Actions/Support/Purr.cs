using ConsoleApp1.Contexts;

namespace ConsoleApp1.Actions.Support;

internal class Purr : IAction
{
    public string Name => "Purr";

    public string Description => "Heals every ally a little bit ^w^";

    public ActionType Type => ActionType.Support;

    public ActionContext Execute(IContext aContext, ITargetable aTarget)
    {
        int fHealApplied = aTarget.ApplyHeal(1);

        return new ActionContext(aContext, this, aTarget, fHealApplied);
    }

    public IEnumerable<ITargetable> ValidTargets(IContext aContext)
    {
        return new List<ITargetable> { (TargetGroup)aContext.Allies.Where(a => a.IsAlive && !a.Equals(aContext.Self)).ToList() };
    }
}
