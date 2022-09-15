using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
