using ConsoleApp1.Actions;

namespace ConsoleApp1.Classes;

internal interface IClass
{
    public string Name { get; }

    public ActionSet ActionSet { get; }
}
