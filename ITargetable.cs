namespace ConsoleApp1
{
    internal interface ITargetable
    {
        public string Name { get; }

        public int ApplyDamage(int aBaseDamage);
        public int ApplyDefense(int aBaseDefense);
        public int ApplyHeal(int aBaseHeal);
    }
}
