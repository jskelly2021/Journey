public enum ActionMaps
{
    UI,
    Player,
    PauseMenu,
    StoreMenu,
}

public static class ActionMapMethods
{
    public static string GetMapName(this ActionMaps map)
    {
        switch (map)
        {
            case ActionMaps.UI:
                return "UI";
            case ActionMaps.Player:
                return "Player";
            case ActionMaps.PauseMenu:
                return "PauseMenu";
            case ActionMaps.StoreMenu:
                return "StoreMenu";
            default:
                return null;
        }
    }
}