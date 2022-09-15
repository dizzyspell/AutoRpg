using ConsoleApp1;
using ConsoleApp1.Actions;
using ConsoleApp1.Classes;
using ConsoleApp1.Contexts;
using ConsoleApp1.Personalities;
using System.Collections.Concurrent;

Console.WriteLine("Hello! Welcome to Goobertown\n");

Console.WriteLine("Please name your character > \n");
string fPlayerName = Console.ReadLine() ?? "Player";
Player fPlayer = new(fPlayerName);

Console.WriteLine("\n");
Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~");
Console.WriteLine("\n");

Console.WriteLine("Ok, here is your current party...\n");

fPlayer.Party.Add(new Character("Nova", new Cultist(), new Angry()));
fPlayer.Party.Add(new Character("Morgan", new TestSubject(), new Balanced()));
fPlayer.Party.Add(new Character("Jake", new TestSubject(), new Shy()));
fPlayer.Party.Add(new Character("Kiki", new Cat(), new Unhinged()));

foreach (ICharacter fMember in fPlayer.Party)
{
    Console.WriteLine(fMember);
    Console.WriteLine("\n");
}

Console.WriteLine("\n");
Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~");
Console.WriteLine("\n");

Party fNpcParty = new Party(new List<ICharacter> {
    new Character("Naruto", new Cat(), new Shy()), 
    new Character("Sasuke", new Cat(), new Angry()),
    Character.GenerateNew(),
    Character.GenerateNew()
});

Console.WriteLine("Generated enemy party...\n");

foreach (Character fMember in fNpcParty)
{
    Console.WriteLine(fMember);
    Console.WriteLine("\n");
}

Console.WriteLine("\n");
Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~");
Console.WriteLine("\n");

BattleContext.SetUpForBattle(fPlayer.Party, fNpcParty);

while (fPlayer.Party.StillKickin && fNpcParty.StillKickin)
{
    BattleContext.NextRound( (aResult) =>
    {
        Console.WriteLine($"> {aResult}\n");
        Console.WriteLine($"{fPlayer.Context.Allies}\n");
        Console.WriteLine($"{fPlayer.Context.Enemies}\n");

        Console.ReadLine();
    });
}

/*for (int i = 0; i < 5; i++)
{
    fPlayer.Reserve.Add(Character.GenerateNew());
}

for (int i = 0; i < 4; i++)
{
    for (int j = 0; j < fPlayer.Reserve.Count; j++)
    {
        Console.WriteLine($"( {j} ) {fPlayer.Reserve[j]}\n");
    }
    Console.WriteLine($"Choose a character for position {i} in your party >\n");

    int fChoice;

    string fInput = Console.ReadLine();

    while (!int.TryParse(fInput, out fChoice) || fChoice >= fPlayer.Reserve.Count)
    {
        Console.WriteLine("Uh.... what ? Try again >\n");
        fInput = Console.ReadLine();
    }

    fPlayer.Party.Add(fPlayer.Reserve[fChoice]);
    fPlayer.Reserve.RemoveAt(fChoice);

    Console.WriteLine("\n");
    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~");
    Console.WriteLine("\n");
}

Console.WriteLine("Ok, here is your current party...\n");

foreach(Character fMember in fPlayer.Party)
{
    Console.WriteLine(fMember);
    Console.WriteLine("\n");
}*/