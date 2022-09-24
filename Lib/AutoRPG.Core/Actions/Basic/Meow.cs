using AutoRPG.Core.Contexts;

namespace AutoRPG.Core.Actions.Basic;

public class Meow : IAction
{
    public string Name => "Meow";

    public string Description => "Charms an enemy into dropping their defenses :3";

    public ActionType Type => ActionType.Basic;

    public ActionContext Execute(IContext aContext, ITargetable aTarget)
    {
        int fDefenseRemoved = -aTarget.ApplyDefense(-1);

        return new ActionContext(aContext, this, aTarget, fDefenseRemoved);
    }

    public IEnumerable<ITargetable> ValidTargets(IContext aContext)
    {
        return aContext.Enemies.Where(a => a.IsAlive).OrderByDescending(a => a.DefensePoints);
    }
}
