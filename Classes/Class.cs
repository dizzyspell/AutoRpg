using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Actions;

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
