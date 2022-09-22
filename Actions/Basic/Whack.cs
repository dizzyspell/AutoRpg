using ConsoleApp1.Contexts;

namespace ConsoleApp1.Actions.Basic
{
    internal class Whack : IAction
    {
        public string Name => "Whack";

        public string Description => "Does some damage";

        public ActionType Type => ActionType.Basic;

        public ActionContext Execute(IContext aContext)
        {
            ICharacter fTarget = RandomNumberGod.ChooseCharacter(aContext.Enemies.Where(a => a.IsAlive));
            int fAdjustedValue = fTarget.ApplyDamage(1);

            return new ActionContext(aContext, this, fTarget, fAdjustedValue);
        }
    }
}
