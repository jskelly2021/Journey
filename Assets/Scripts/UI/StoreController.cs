public static class StoreController
{
    public static void Init() {}

    public static void OpenStore()
    {
        UIEvents.EnableCanvas(UICanvases.StoreMenu, true);
        InputEvents.EnableActionMap("StoreMenu");
        InputEvents.DisableActionMap("Player");
    }

    public static void CloseStore()
    {
        UIEvents.EnableCanvas(UICanvases.StoreMenu, false);
        InputEvents.EnableActionMap("Player");
        InputEvents.DisableActionMap("StoreMenu");
    }

    public static void BuyItem()
    {

    }

    public static void SellItem()
    {

    }
}
