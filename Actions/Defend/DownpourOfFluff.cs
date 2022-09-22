using ConsoleApp1.Contexts;

namespace ConsoleApp1.Actions.Defend
{
    internal class DownpourOfFluff : IAction
    {
        public string Name => "Downpour of Fluff";

        public string Description => "Sheds some protective fluff on all friends <3";

        public ActionType Type => ActionType.Defend;

        public ActionContext Execute(IContext aContext)
        {
            ITargetable fTarget = (TargetGroup) aContext.Allies.Where(a => a.IsAlive && !a.Equals(aContext.Self)).ToList();
            int fDefenseApplied = fTarget.ApplyDefense(1);

            return new ActionContext(aContext, this, fTarget, fDefenseApplied);
        }
    }
}
