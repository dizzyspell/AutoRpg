using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Contexts;

namespace ConsoleApp1.Actions.Support
{
    internal class Heal : IAction
    {
        public string Name => "Heal";

        public string Description => "Heals some damage";

        public ActionType Type => ActionType.Support;

        public ActionContext Execute(IContext aContext)
        {
            int fAdjustedValue = aContext.Self.ApplyHeal(2);

            return new ActionContext(aContext, this, aContext.Self, fAdjustedValue);
        }
    }
}
