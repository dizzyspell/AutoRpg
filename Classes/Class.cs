namespace ConsoleApp1.Classes
{
    internal abstract class Class
    {
        public abstract string Name { get; }

        public override string ToString()
        {
            return Name;
        }
    }
}
