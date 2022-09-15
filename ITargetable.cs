using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
