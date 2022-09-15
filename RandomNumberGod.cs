using ConsoleApp1.Classes;
using ConsoleApp1.Personalities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class RandomNumberGod
    {
        private static readonly Random msrRng = new();

        public static int ChooseInt(int aMax = 10) => msrRng.Next(0, aMax);

        public static string ChooseName() => Defaults.Names[msrRng.Next(0, Defaults.Names.Count)];

        public static IClass ChooseClass() => Defaults.Classes.ElementAt(ChooseInt(Defaults.Classes.Count)).Value.Invoke();

        public static IPersonality ChoosePersonality() => Defaults.Personalities.ElementAt(ChooseInt(Defaults.Personalities.Count)).Value.Invoke();

        public static ICharacter ChooseCharacter(IEnumerable<ICharacter> aPool) => aPool.ElementAt(ChooseInt(aPool.Count()));
    }
}
