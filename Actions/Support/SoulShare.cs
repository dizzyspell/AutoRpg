using ConsoleApp1.Contexts;

namespace ConsoleApp1.Actions.Support
{
    internal class SoulShare : IAction
    {
        public string Name => "Soul Share";

        public string Description => "Steal health from the strongest friend to heal the weakest!";

        public ActionType Type => ActionType.Support;

        public ActionContext Execute(IContext aContext)
        {
            IEnumerable<ICharacter> fSortedByHealth = aContext.Allies.Where(a => a.IsAlive).OrderByDescending(a => a.HealthPoints);
            ICharacter fSource = fSortedByHealth.First();
            ICharacter fDestination = fSortedByHealth.Last();

            int fAdjustedValue = 2 * fDestination.ApplyHeal(1);
            fSource.ApplyDamage(fAdjustedValue);

            return new ActionContext(aContext, this, fDestination, fAdjustedValue);
        }
    }
}
