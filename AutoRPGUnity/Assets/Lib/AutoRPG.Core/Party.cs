using System.Collections;

namespace AutoRPG.Core;

/// <summary>
///     A standardized group of allied characters. Also an <see cref="ITargetable" />.
/// </summary>
public class Party : IEnumerable<ICharacter?>, ITargetable
{
    private readonly ICharacter?[] mrCharacters = new ICharacter?[4];

    public Party()
    {
    }

    /// <summary>
    ///     Generate a new party from the first four characters in a list. List should
    ///     have at least 4 characters or this will blow up. I promise I'll fix it
    ///     eventually.... :3
    /// </summary>
    /// <param name="aCharacters">
    ///     The list of characters to build the party around. Should
    ///     have at least 4 characters or this will blow up. I promise I'll fix it
    ///     eventually.... :3
    /// </param>
    public Party(List<ICharacter> aCharacters)
    {
        for (int i = 0; i < 4; i++) mrCharacters[i] = aCharacters.ElementAt(i);
    }

    /// <summary>
    ///     True if there is at least one character in the party who is still alive.
    ///     False otherwise.
    /// </summary>
    public bool StillKickin => mrCharacters.Any(a => a is { IsAlive: true });

    /// <summary>
    ///     How many characters are actually in the party, ignoring empty slots.
    /// </summary>
    public int Count => mrCharacters.Count(a => a != null);

    /// <summary>
    ///     User-presentable summary of who's in the party, and any empty slots.
    ///     Mainly for the console app.
    /// </summary>
    public string Summary
    {
        get
        {
            string fToReturn = "";

            for (int i = 0; i < 4; i++)
            {
                ICharacter? fMember = mrCharacters[i];
                fToReturn += fMember == null
                    ? $"({i}) < EMPTY > \n"
                    : $"({i}) {fMember.Summary} \n";
            }

            return fToReturn;
        }
    }

    /// <summary>
    ///     User-presentable table of each character in the party, with how much
    ///     HP and DP each character has.
    /// </summary>
    public string Details
    {
        get
        {
            string fToReturn = "";

            foreach (ICharacter? fMember in mrCharacters)
            {
                fToReturn += fMember == null
                    ? "\t< EMPTY >\n"
                    : $"\t{fMember.Name}:{(fMember.Name.Length >= 8 ? "\t" : "\t\t")}{fMember.HealthPoints} \t{fMember.DefensePoints}\n";
            }

            return fToReturn;
        }
    }

    public IEnumerator<ICharacter> GetEnumerator()
    {
        return mrCharacters.ToList()
            .GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public string Name => throw new NotImplementedException();

    public int SimulateDamage(int aBaseDamage)
    {
        return ((TargetGroup) this).SimulateDamage(aBaseDamage);
    }

    public int ApplyDamage(int aBaseDamage)
    {
        return ((TargetGroup) this).ApplyDamage(aBaseDamage);
    }

    public int SimulateDefense(int aBaseDefense)
    {
        return ((TargetGroup) this).SimulateDefense(aBaseDefense);
    }

    public int ApplyDefense(int aBaseDefense)
    {
        return ((TargetGroup) this).ApplyDefense(aBaseDefense);
    }

    public int SimulateHeal(int aBaseHeal)
    {
        return ((TargetGroup) this).SimulateHeal(aBaseHeal);
    }

    public int ApplyHeal(int aBaseHeal)
    {
        return ((TargetGroup) this).ApplyHeal(aBaseHeal);
    }

    /// <summary>
    ///     Generate a new party with four random characters
    /// </summary>
    /// <returns></returns>
    public static Party GenerateNew()
    {
        return new Party(
            new List<ICharacter>
            {
                Character.GenerateNew(),
                Character.GenerateNew(),
                Character.GenerateNew(),
                Character.GenerateNew()
            }
        );
    }

    /// <summary>
    ///     Put the given character in the specified slot in the party.
    /// </summary>
    /// <param name="aPos">0-indexed position in the party to place the character.</param>
    /// <param name="aCharacter">The character to place in the slot.</param>
    public void SetPosition(int aPos, ICharacter aCharacter)
    {
        if (aPos < 4) mrCharacters[aPos] = aCharacter;
    }
}