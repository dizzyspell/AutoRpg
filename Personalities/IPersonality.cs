using ConsoleApp1.Actions;
using ConsoleApp1.Contexts;

namespace ConsoleApp1.Personalities;

internal interface IPersonality
{
    public string Name { get; }
    public IContext Context { get; set; }

    public ActionContext DoAnyAction(ActionSet aActionSet);
}
