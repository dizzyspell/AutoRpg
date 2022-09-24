using AutoRPG.Core.Contexts;

namespace AutoRPG.Core.Actions;

public interface IAction
{
    public string Name { get; }

    public string Description { get; }

    public ActionType Type { get; }

    public ActionContext Execute(IContext aContext, ITargetable aTarget);

    public IEnumerable<ITargetable> ValidTargets(IContext aContext);
}
