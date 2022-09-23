using ConsoleApp1.Contexts;

namespace ConsoleApp1.Actions.Support;

internal class SoulShare : IAction
{
    public string Name => "Soul Share";

    public string Description => "Steal health from the strongest friend to heal the weakest!";

    public ActionType Type => ActionType.Support;

    public ActionContext Execute(IContext aContext, ITargetable aTarget)
    {
        IEnumerable<ICharacter> fSortedByHealth = aContext.Allies.Where(a => a.IsAlive).OrderByDescending(a => a.HealthPoints);
        ICharacter fSource = fSortedByHealth.First();

        int fAdjustedValue = 2 * aTarget.ApplyHeal(1);
        fSource.ApplyDamage(fAdjustedValue);

        return new ActionContext(aContext, this, aTarget, fAdjustedValue);
    }

    public IEnumerable<ITargetable> ValidTargets(IContext aContext)
    {
        return aContext.Allies.Where(a => a.IsAlive).OrderBy(a => a.HealthPoints);
    }
}
