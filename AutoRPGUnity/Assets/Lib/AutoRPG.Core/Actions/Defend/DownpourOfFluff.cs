using System.Collections.Generic;
using System.Linq;
using AutoRPG.Core.Contexts;

namespace AutoRPG.Core.Actions.Defend
{
    public class DownpourOfFluff : IAction
    {
        public string Name => "Downpour of Fluff";

        public string Description =>
            "Sheds some protective fluff on all friends <3";

        public ActionType Type => ActionType.Defend;

        public ActionContext Execute(IContext aContext, ITargetable aTarget)
        {
            var fDefenseApplied = aTarget.ApplyDefense(1);

            return new ActionContext(aContext, this, aTarget, fDefenseApplied);
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