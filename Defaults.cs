using ConsoleApp1.Actions;
using ConsoleApp1.Classes;
using ConsoleApp1.Personalities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal static class Defaults
    {
        public const string ClassTestSubjectToken = "class_testsubject";
        public const string ClassCultistToken = "class_cultist";
        public const string ClassCatToken = "class_cat";

        public const string PersonalityUnhingedToken = "unhinged_person";
        public const string PersonalityAngryToken = "angry_person";
        public const string PersonalityStoicToken = "stoic_person";
        public const string PersonalityKindToken = "personality_kind";
        public const string PersonalityRelaxedToken = "relaxed_person";
        public const string PersonalityShyToken = "shy_person";

        public static readonly List<string> Names = new List<string>
        {
            "T. Testerson",
            "Jimmy Test",
            "Kianna 'Big Mood' Johnson",
            "THE Goober",
            "Frank Sinatra",
            "Jurgen Windcaller",
            "Cicero",
            "Juicifer",
            "Mochi",
            "Mandu",
            "Fondue",
            "Rondue",
            "Shaggy",
            "Frogge",
            "Dinky",
            "Cecil",
            "Susil",
            "Koschack",
            "Ligma"
        };

        public static readonly Dictionary<string, Func<IClass>> Classes = new Dictionary<string, Func<IClass>>() 
        {
            { ClassTestSubjectToken, () => new Classes.TestSubject() },
            { ClassCultistToken, () => new Classes.Cultist() },
            { ClassCatToken, () => new Classes.Cat() },
        };

        public static readonly Dictionary<string, Func<IPersonality>> Personalities = new Dictionary<string, Func<IPersonality>>()
        {
            { PersonalityUnhingedToken, () => new Personalities.Unhinged() },
            { PersonalityAngryToken, () => new Personalities.Angry() },
            { PersonalityStoicToken, () => new Personalities.Stoic() },
            { PersonalityKindToken, () => new Personalities.Kind() },
            { PersonalityShyToken, () => new Personalities.Shy() },
        };
    }
}
