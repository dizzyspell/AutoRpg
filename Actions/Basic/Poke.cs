using ConsoleApp1.Contexts;

namespace ConsoleApp1.Actions.Basic;

internal class Poke : IAction
{
    public string Name => "Poke";

    public string Description => "Poke the weakest enemy";

    public ActionType Type => ActionType.Basic;

    public ActionContext Execute(IContext aContext, ITargetable aTarget)
    {
        int fAdjusted = aTarget.ApplyDamage(1);

        return new ActionContext(aContext, this, aTarget, fAdjusted);
    }

    public IEnumerable<ITargetable> ValidTargets(IContext aContext)
    {
        return aContext.Enemies.Where(a => a.IsAlive).OrderBy(a => a.HealthPoints);
    }
}
