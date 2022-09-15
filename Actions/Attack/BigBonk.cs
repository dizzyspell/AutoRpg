using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Contexts;

namespace ConsoleApp1.Actions.Attack
{
    internal class BigBonk : IAction
    {
        public string Name => "Big Bonk";

        public string Description => "Does lots of damage";

        public ActionType Type => ActionType.Attack;

        public ActionContext Execute(IContext aContext)
        {
            ICharacter fTarget = RandomNumberGod.ChooseCharacter(aContext.Enemies.Where( a => a.IsAlive ));
            int fAdjustedDamage = fTarget.ApplyDamage(2);

            return new ActionContext(aContext, this, fTarget, fAdjustedDamage);
        }
    }
}
