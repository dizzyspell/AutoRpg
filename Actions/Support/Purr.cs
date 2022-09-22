using ConsoleApp1.Contexts;

namespace ConsoleApp1.Actions.Support;

internal class Purr : IAction
{
    public string Name => "Purr";

    public string Description => "Heals every ally a little bit ^w^";

    public ActionType Type => ActionType.Support;

    public ActionContext Execute(IContext aContext)
    {
        ITargetable fTarget = (TargetGroup) aContext.Allies.Where(a => a.IsAlive && !a.Equals(aContext.Self)).ToList();
        int fHealApplied = fTarget.ApplyHeal(1);

        return new ActionContext(aContext, this, fTarget, fHealApplied);
    }
}
