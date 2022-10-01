using System.Collections.Generic;
using System.Linq;
using AutoRPG.Core.Contexts;

namespace AutoRPG.Core.Actions.Support
{
    public class Purr : IAction
    {
        public string Name => "Purr";

        public string Description => "Heals every ally a little bit ^w^";

        public ActionType Type => ActionType.Support;

        public ActionContext Execute(IContext aContext, ITargetable aTarget)
        {
            var fHealApplied = aTarget.ApplyHeal(1);

            return new ActionContext(aContext, this, aTarget, fHealApplied);
        }

        public IEnumerable<ITargetable> ValidTargets(IContext aContext)
        {
            return new List<ITargetable>
            {
                (TargetGroup)aContext.Allies
                    .Where(a => a.IsAlive && !a.Equals(aContext.Self))
                    .ToList()
            };
        }
    }
}