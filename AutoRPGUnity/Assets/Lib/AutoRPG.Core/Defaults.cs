using AutoRPG.Core.Classes;
using AutoRPG.Core.Personalities;

namespace AutoRPG.Core;

/// <summary>
///     A big list of stuff that can be randomly selected to make a new character.
///     this is weird and janky rn, it will be changing so dont pay too much attention...
/// </summary>
public static class Defaults
{
    public const string ClassTestSubjectToken = "class_testsubject";
    public const string ClassCultistToken     = "class_cultist";
    public const string ClassCatToken         = "class_cat";

    public const string PersonalityUnhingedToken = "unhinged_person";
    public const string PersonalityAngryToken    = "angry_person";
    public const string PersonalityStoicToken    = "stoic_person";
    public const string PersonalityKindToken     = "personality_kind";
    public const string PersonalityRelaxedToken  = "relaxed_person";
    public const string PersonalityShyToken      = "shy_person";

    public static readonly List<string> Names = new()
    {
        "T. Testerson",
        "Jimmy Test",
        "Kianna",
        "THE Goober",
        "Frank Sinatra",
        "JoJo",
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

    public static readonly Dictionary<string, Func<IClass>> Classes = new()
    {
        { ClassTestSubjectToken, () => new TestSubject() },
        { ClassCultistToken, () => new Cultist() },
        { ClassCatToken, () => new Cat() }
    };

    public static readonly Dictionary<string, Func<IPersonality>>
        Personalities = new()
        {
            { PersonalityUnhingedToken, () => new Unhinged() },
            { PersonalityAngryToken, () => new Angry() },
            { PersonalityStoicToken, () => new Stoic() },
            { PersonalityKindToken, () => new Kind() },
            { PersonalityShyToken, () => new Shy() }
        };
}