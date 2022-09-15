using ConsoleApp1.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Actions.Defend
{
    internal class FleshShield : IAction
    {
        public string Name => "Flesh Shield";

        public string Description => "Steal some skin from the strongest friend and use it for defense!!";

        public ActionType Type => ActionType.Defend;

        public ActionContext Execute(IContext aContext)
        {
            IEnumerable<ICharacter> fSortedByHealth = aContext.Allies.Where(a => a.IsAlive).OrderByDescending(a => a.HealthPoints);
            ICharacter fSource = fSortedByHealth.First();
            ICharacter fDestination = fSortedByHealth.Last();


            int fAdjustedValue = 2 * ((fSource.HealthPoints == 1) ? 0 : fSource.ApplyDamage(1));
            fDestination.ApplyDefense(fAdjustedValue);

            return new ActionContext(aContext, this, fDestination, fAdjustedValue);
        }
    }
}
