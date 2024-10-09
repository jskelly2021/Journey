using UnityEngine;

public class StoreButton: MonoBehaviour
{
    public void openStore() => StoreController.OpenStore();
    public void closeStore() => StoreController.CloseStore();
}