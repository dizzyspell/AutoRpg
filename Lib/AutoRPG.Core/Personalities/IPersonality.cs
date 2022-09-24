using AutoRPG.Core.Actions;
using AutoRPG.Core.Contexts;

namespace AutoRPG.Core.Personalities;

public interface IPersonality
{
    public string Name { get; }
    public IContext Context { get; set; }

    public ActionContext DoAnyAction(ActionSet aActionSet);
}
