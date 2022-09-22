using ConsoleApp1.Actions;
using ConsoleApp1.Classes;
using ConsoleApp1.Contexts;
using ConsoleApp1.Personalities;

namespace ConsoleApp1
{
    internal interface ICharacter : ITargetable
    {
        public Guid Id { get; }
        public IClass Class { get; }
        public IPersonality Personality { get; }
        public ActionSet ActionSet { get; }
        public int HealthPoints { get; }
        public int DefensePoints { get; }
        public bool IsAlive { get; }
        public string Summary { get; }
        public IContext Context { get; set; }

        public IAction ChooseAction();
        public ActionContext Execute(IAction aAction);
        public void ResetForRound();
    }
}
