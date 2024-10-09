public static class StoreManager
{
    static StoreManager()
    {
        StoreEvents.OnOpenStore += OpenStore;
        StoreEvents.OnCloseStore += CloseStore;
    }

    public static void Init() {}

    private static void OpenStore()
    {
        UIEvents.EnableCanvas(UICanvases.StoreMenu, true);
        InputEvents.EnableActionMap("StoreMenu");
        InputEvents.DisableActionMap("Player");
    }

    private static void CloseStore()
    {
        UIEvents.EnableCanvas(UICanvases.StoreMenu, false);
        InputEvents.EnableActionMap("Player");
        InputEvents.DisableActionMap("StoreMenu");
    }

    private static void BuyItem()
    {

    }

    private static void SellItem()
    {

    }
}
