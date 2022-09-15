using ConsoleApp1.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Classes
{
    internal interface IClass
    {
        public string Name { get; }

        public ActionSet ActionSet { get; }
    }
}
