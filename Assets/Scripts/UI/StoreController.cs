public static class StoreController
{
    public static void Init() {}

    public static void OpenStore()
    {
        UIEvents.EnableCanvas(UICanvases.HUD, false);
        UIEvents.EnableCanvas(UICanvases.StoreMenu, true);
        InputEvents.EnableActionMap(ActionMaps.StoreMenu);
        InputEvents.EnableActionMap(ActionMaps.UI);
        InputEvents.DisableActionMap(ActionMaps.Player);
    }

    public static void CloseStore()
    {
        UIEvents.EnableCanvas(UICanvases.StoreMenu, false);
        UIEvents.EnableCanvas(UICanvases.HUD, true);
        InputEvents.EnableActionMap(ActionMaps.Player);
        InputEvents.DisableActionMap(ActionMaps.StoreMenu);
        InputEvents.DisableActionMap(ActionMaps.UI);
    }

    public static void BuyItem()
    {

    }

    public static void SellItem()
    {

    }
}
