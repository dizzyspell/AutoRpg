using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Party : IEnumerable<ICharacter>, ITargetable
    {
        private readonly List<ICharacter> mrCharacters;

        public Party()
        {
            mrCharacters = new List<ICharacter>();
        }

        public Party(List<ICharacter> aCharacters)
        {
            mrCharacters = aCharacters;
        }

        public int Count => mrCharacters.Count;

        public bool StillKickin => mrCharacters.Any(a => a.IsAlive);

        public string Name => throw new NotImplementedException();

        public void Add(ICharacter aToAdd)
        {
            mrCharacters.Add(aToAdd);
        }

        public override string ToString()
        {
            string fToReturn = "";

            foreach (var fMember in mrCharacters)
            {
                fToReturn += $"{fMember.Name}: {fMember.HealthPoints} | {fMember.DefensePoints}\n";
            }

            return fToReturn;
        }

        public IEnumerator<ICharacter> GetEnumerator()
        {
            return mrCharacters.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int ApplyDamage(int aBaseDamage)
        {
            return ((TargetGroup) mrCharacters).ApplyDamage(aBaseDamage);
        }

        public int ApplyDefense(int aBaseDefense)
        {
            return ((TargetGroup) mrCharacters).ApplyDefense(aBaseDefense);
        }

        public int ApplyHeal(int aBaseHeal)
        {
            return ((TargetGroup) mrCharacters).ApplyHeal(aBaseHeal);
        }

        public static implicit operator List<ICharacter>(Party p) => p.mrCharacters;
    }
}
