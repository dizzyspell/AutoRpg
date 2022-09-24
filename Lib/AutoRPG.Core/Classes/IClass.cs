using AutoRPG.Core.Actions;

namespace AutoRPG.Core.Classes;

public interface IClass
{
    public string Name { get; }

    public ActionSet ActionSet { get; }
}
