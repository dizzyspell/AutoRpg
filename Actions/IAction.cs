using ConsoleApp1.Contexts;

namespace ConsoleApp1.Actions
{
    internal interface IAction
    {
        public string Name { get; }

        public string Description { get; }

        public ActionType Type { get; }

        public ActionContext Execute(IContext aContext);
    }
}
