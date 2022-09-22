using ConsoleApp1.Contexts;

namespace ConsoleApp1.Actions.Basic
{
    internal class Meow : IAction
    {
        public string Name => "Meow";

        public string Description => "Charms an enemy into dropping their defenses :3";

        public ActionType Type => ActionType.Basic;

        public ActionContext Execute(IContext aContext)
        {
            ITargetable fTarget = aContext.Enemies.Where(a => a.IsAlive).OrderByDescending(a => a.DefensePoints).First();
            int fDefenseRemoved = -fTarget.ApplyDefense(-1);

            return new ActionContext(aContext, this, fTarget, fDefenseRemoved);
        }
    }
}
