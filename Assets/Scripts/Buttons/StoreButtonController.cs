using UnityEngine;

public class StoreButtonController: MonoBehaviour
{
    public void openStore() => StoreController.OpenStore();
    public void closeStore() => StoreController.CloseStore();
}