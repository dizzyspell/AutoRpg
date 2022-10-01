using System.Collections.Generic;
using System.Linq;
using AutoRPG.Core.Contexts;

namespace AutoRPG.Core.Actions.Attack
{
    public class BigBonk : IAction
    {
        public string Name => "Big Bonk";

        public string Description => "Does lots of damage";

        public ActionType Type => ActionType.Attack;

        public ActionContext Execute(IContext aContext, ITargetable aTarget)
        {
            var fAdjustedDamage = aTarget.ApplyDamage(2);

            return new ActionContext(aContext, this, aTarget, fAdjustedDamage);
        }

        public IEnumerable<ITargetable> ValidTargets(IContext aContext)
        {
            return aContext.Enemies.Where(a => a.IsAlive);
        }
    }
}