using System.Collections;

namespace AutoRPG.Core;

public class Party : IEnumerable<ICharacter>, ITargetable
{
    private readonly ICharacter[] mrCharacters = new ICharacter[4];

    public Party()
    {
    }

    public Party(List<ICharacter> aCharacters)
    {
        for (int i = 0; i < 4; i++)
        {
            mrCharacters[i] = aCharacters.ElementAt(i);
        }
    }

    public static Party GenerateNew()
    {
        return new Party(
            new List<ICharacter> {
                Character.GenerateNew(),
                Character.GenerateNew(),
                Character.GenerateNew(),
                Character.GenerateNew(),
            }
        );
    }

    public bool StillKickin => mrCharacters.Any(a => a.IsAlive);

    public int Count => mrCharacters.Where(a => a != null).Count();

    public string Summary
    {
        get
        {
            string fToReturn = "";

            for (int i = 0; i < 4; i++)
            {
                ICharacter fMember = mrCharacters[i];
                fToReturn += fMember == null ?
                    $"({i}) < EMPTY > \n" :
                    $"({i}) {fMember.Summary} \n";
            }

            return fToReturn;
        }
    }

    public string Details
    {
        get
        {
            string fToReturn = "";

            foreach (var fMember in mrCharacters)
            {
                fToReturn += fMember == null ?
                    "\t< EMPTY >\n" :
                    $"\t{fMember.Name}:{(fMember.Name.Length >= 8 ? "\t" : "\t\t")}{fMember.HealthPoints} \t{fMember.DefensePoints}\n";
            }

            return fToReturn;
        }
    }

    public void SetPosition(int aPos, ICharacter aCharacter)
    {
        if (aPos < 4) mrCharacters[aPos] = aCharacter;
    }

    public string Name => throw new NotImplementedException();

    public IEnumerator<ICharacter> GetEnumerator()
    {
        return mrCharacters.ToList().GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public int SimulateDamage(int aBaseDamage) => ((TargetGroup)this).SimulateDamage(aBaseDamage);

    public int ApplyDamage(int aBaseDamage) => ((TargetGroup)this).ApplyDamage(aBaseDamage);

    public int SimulateDefense(int aBaseDefense) => ((TargetGroup)this).SimulateDefense(aBaseDefense);

    public int ApplyDefense(int aBaseDefense) => ((TargetGroup)this).ApplyDefense(aBaseDefense);

    public int SimulateHeal(int aBaseHeal) => ((TargetGroup)this).SimulateHeal(aBaseHeal);

    public int ApplyHeal(int aBaseHeal) => ((TargetGroup)this).ApplyHeal(aBaseHeal);
}
