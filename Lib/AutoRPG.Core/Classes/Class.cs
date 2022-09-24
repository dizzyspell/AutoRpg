namespace AutoRPG.Core.Classes;

public abstract class Class
{
    public abstract string Name { get; }

    public override string ToString()
    {
        return Name;
    }
}
