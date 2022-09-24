namespace AutoRPG.Core;

public interface ITargetable
{
    public string Name { get; }

    public int ApplyDamage(int aBaseDamage);
    public int ApplyDefense(int aBaseDefense);
    public int ApplyHeal(int aBaseHeal);
    public int SimulateDamage(int aBaseDamage);
    public int SimulateDefense(int aBaseDefense);
    public int SimulateHeal(int aBaseHeal);
}
