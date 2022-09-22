using ConsoleApp1.Contexts;

namespace ConsoleApp1;

internal static class Player
{
    private const int mcDefaultStartingMoney = 100;

    private static readonly Party msrParty = new();
    private static readonly List<ICharacter> msrReserve = new();

    static Player()
    {
        Name = "";
        Money = 0;
    }

    public static void Initialize(string aName, int? aStartingMoney = null)
    {
        Name = aName;
        Money = aStartingMoney ?? mcDefaultStartingMoney;
        for (int i = 0; i < 5; i++)
        {
            msrReserve.Add(Character.GenerateNew());
        }
    }

    public static string Name { get; set; }

    public static int Money { get; set; }

    public static Party Party => msrParty;

    public static List<ICharacter> Reserve => msrReserve;

    public static IContext Context => msrParty.First().Context;
}
