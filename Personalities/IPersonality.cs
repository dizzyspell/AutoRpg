using ConsoleApp1.Actions;

namespace ConsoleApp1.Personalities;

internal interface IPersonality
{
    public string Name { get; }

    public IAction ChooseAction(ActionSet aActionSet);
}
