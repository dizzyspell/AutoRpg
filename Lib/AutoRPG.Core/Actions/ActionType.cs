namespace AutoRPG.Core.Actions;

/// <summary>
/// A classification of an action - this mainly exists so that we don't have to 
/// use reflection to get this information.
/// </summary>
public enum ActionType
{
    Basic,
    Support,
    Defend,
    Attack
}
