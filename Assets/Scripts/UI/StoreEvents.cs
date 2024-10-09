using System;

public class StoreEvents
{
    public static event Action OnOpenStore;
    public static event Action OnCloseStore;

    public static void OpenStore() => OnOpenStore?.Invoke();
    public static void CloseStore() => OnCloseStore?.Invoke();
}