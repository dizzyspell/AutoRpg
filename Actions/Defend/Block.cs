using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Contexts;

namespace ConsoleApp1.Actions.Defend
{
    internal class Block : IAction
    {
        public string Name => "Block";

        public string Description => "Prevents some damage";

        public ActionType Type => ActionType.Defend;

        public ActionContext Execute(IContext aContext)
        {
            int fAdjustedValue = aContext.Self.ApplyDefense(1);

            return new ActionContext(aContext, this, aContext.Self, fAdjustedValue);
        }
    }
}
