using ConsoleApp1.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal static class ConsoleManager
    {
        public static void StartGame()
        {
            Console.WriteLine("Hello! Welcome to Goobertown\n");

            Console.WriteLine("What is your name? > \n");
            string fPlayerName = Console.ReadLine() ?? "Player";
            Player.Initialize(fPlayerName);
        }

        public static void ShowSeparator()
        {
            Console.WriteLine("\n");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("\n");
        }

        public static void ManageParty()
        {
            string fInput;

            while (true)
            {
                Console.WriteLine("\nHere is your current party...\n");

                Console.WriteLine(Player.Party.Summary);

                if (Player.Party.Count == 4)
                {
                    Console.WriteLine("\nAll finished? (y/n) > \n");
                    fInput = Console.ReadLine();

                    if (fInput.ToLower() == "y") break;
                }

                Console.WriteLine("Which slot would you like to edit? > \n");

                int fChosenSlot;
                fInput = Console.ReadLine();

                while (!int.TryParse(fInput, out fChosenSlot) || fChosenSlot >= 4)
                {
                    Console.WriteLine("\nUh.... what ? Try again >\n");
                    fInput = Console.ReadLine();
                }

                Console.WriteLine("\nOk, here is your current reserve...\n");

                for (int i = 0; i < Player.Reserve.Count; i++)
                {
                    Console.WriteLine($"({i}) {Player.Reserve.ElementAt(i).Summary}");
                }

                Console.WriteLine($"\nWhich character should be in slot {fChosenSlot} of your party? > \n");

                int fChosenChar;
                fInput = Console.ReadLine();

                while (!int.TryParse(fInput, out fChosenChar) || fChosenChar >= Player.Reserve.Count)
                {
                    Console.WriteLine("\nUh.... what ? Try again >\n");
                    fInput = Console.ReadLine();
                    Console.WriteLine("\n");
                }

                if (Player.Party.ElementAt(fChosenSlot) != null) Player.Reserve.Add(Player.Party.ElementAt(fChosenSlot));
                Player.Party.SetPosition(fChosenSlot, Player.Reserve.ElementAt(fChosenChar));
                Player.Reserve.RemoveAt(fChosenChar);
            }
        }

        public static void StartGambling()
        {
            string fInput;
            Party fPredictedWinner;
            Party fWinningParty;
            bool fWatchTheBattle;

            bool fContinue = true;

            while (fContinue)
            {
                Party fPartyA = Party.GenerateNew();
                Party fPartyB = Party.GenerateNew();

                Console.WriteLine("Starting match... \n");

                Console.WriteLine("These parties are going head-to-head \n");
                Console.WriteLine($"Party A: \n{fPartyA.Summary} \n");
                Console.WriteLine($"Party B: \n{fPartyB.Summary} \n");
                Console.WriteLine("Which party do you think will win? (a/b) > \n");

                fInput = Console.ReadLine();

                while (fInput.ToLower() != "a" && fInput.ToLower() != "b")
                {
                    Console.WriteLine("\nUh.... what ? Try again > \n");
                    fInput = Console.ReadLine();
                }

                // Only two possiblities here, given the above while loop
                fPredictedWinner = fInput.ToLower() == "a" ? fPartyA : fPartyB;
                Console.WriteLine("Bet placed! -10 Money \n");
                Player.Money -= 10;
                Console.WriteLine($"New total is {Player.Money} Monies \n");

                fWatchTheBattle = YesNoPrompt("Would you like to watch the battle?");

                fWinningParty = RunBattle(fPartyA, fPartyB, fWatchTheBattle);

                if (fWinningParty == fPredictedWinner)
                {
                    Console.WriteLine("You were right!! +20 Money \n");
                    Player.Money += 20;
                    Console.WriteLine($"New total is {Player.Money} Monies");
                }
                else
                {
                    Console.WriteLine("You were wrong... oof... awkward... MASSIVE yikes... \n");
                }

                fContinue = YesNoPrompt("Would you like to bet on another roud?");
            }
        }

        public static Party RunBattle(Party aPartyA, Party aPartyB, bool aPauseForRound = true)
        {
            BattleContext.SetUpForBattle(aPartyA, aPartyB);
            while (aPartyA.StillKickin && aPartyB.StillKickin)
            {
                BattleContext.NextRound(
                    aContext =>
                    {
                        Console.WriteLine($"\t!! {aContext.Self.Name} used {aContext.Executed.Name} on {aContext.Target.Name} !! \n");
                        Console.WriteLine($"{aPartyA}\n{aPartyB}");
                        if (aPauseForRound) Pause();
                    }
                );
            }

            return aPartyA.StillKickin ? aPartyA : aPartyB;
        }

        public static void Pause()
        {
            Console.WriteLine("\n[ press Enter to continue ]");
            Console.ReadLine();
        }

        public static bool YesNoPrompt(string aMessage)
        {
            string fInput = "";

            Console.WriteLine($"{aMessage} > (y/n) \n");
            fInput = Console.ReadLine();

            while(!fInput.ToLower().Contains("y") && !fInput.ToLower().Contains("n"))
            {
                Console.WriteLine("\nUh.... what ? Try again >\n");
                fInput = Console.ReadLine();
                Console.WriteLine("\n");
            }

            return fInput.ToLower().Contains("y");
        }
    }
}
