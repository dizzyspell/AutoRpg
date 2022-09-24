using AutoRPG.Core;
using AutoRPG.Core.Contexts;

namespace AutoRPG.ConsoleApp;

public static class Player
{
    private const int mcDefaultStartingMoney = 100;

    static Player()
    {
        Name  = "";
        Money = 0;
    }

    public static string Name { get; set; }

    public static int Money { get; set; }

    public static Party Party { get; } = new();

    public static List<ICharacter> Reserve { get; } = new();

    public static IContext Context => Party.First().Context;

    public static void Initialize(string aName, int? aStartingMoney = null)
    {
        Name  = aName;
        Money = aStartingMoney ?? mcDefaultStartingMoney;
        for (int i = 0; i < 5; i++) Reserve.Add(Character.GenerateNew());
    }
}