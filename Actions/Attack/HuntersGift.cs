using ConsoleApp1.Contexts;

namespace ConsoleApp1.Actions.Attack
{
    internal class HuntersGift : IAction
    {
        public string Name => "Hunter's Gift";

        public string Description => "Steal a mouse from an enemy and bring it to a friend!";

        public ActionType Type => ActionType.Attack;

        public ActionContext Execute(IContext aContext)
        {
            ITargetable fTarget = RandomNumberGod.ChooseCharacter(aContext.Enemies.Where(a => a.IsAlive));
            int fDamageDone = fTarget.ApplyDamage(1);
            ITargetable fDestination = aContext.Allies.Where(a => a.IsAlive).OrderByDescending(a => a.HealthPoints).Last();
            fDestination.ApplyHeal(fDamageDone);

            return new ActionContext(aContext, this, fTarget, fDamageDone);
        }
    }
}
