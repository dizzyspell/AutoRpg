using AutoRPG.Core.Contexts;

namespace AutoRPG.Core.Actions.Defend;

public class FleshShield : IAction
{
    public string Name => "Flesh Shield";

    public string Description => "Steal some skin from the strongest friend and use it for defense!!";

    public ActionType Type => ActionType.Defend;

    public ActionContext Execute(IContext aContext, ITargetable aTarget)
    {
        IEnumerable<ICharacter> fSortedByHealth = aContext.Allies.Where(a => a.IsAlive).OrderByDescending(a => a.HealthPoints);
        ICharacter fSource = fSortedByHealth.First();

        int fAdjustedValue = 2 * (fSource.HealthPoints == 1 ? 0 : fSource.ApplyDamage(1));
        aTarget.ApplyDefense(fAdjustedValue);

        return new ActionContext(aContext, this, aTarget, fAdjustedValue);
    }

    public IEnumerable<ITargetable> ValidTargets(IContext aContext)
    {
        return aContext.Allies.Where(a => a.IsAlive).OrderBy(a => a.HealthPoints);
    }
}
