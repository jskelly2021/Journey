using UnityEngine.InputSystem;

public class StoreMenuInputHandler : InputHandler, PlayerInputAction.IStoreMenuActions
{
    public StoreMenuInputHandler(PlayerInputAction playerInput) : base(playerInput)
    {
        playerInput.StoreMenu.SetCallbacks(this);
    }

    public void OnExitMenu(InputAction.CallbackContext context)
    {
        if (context.phase != InputActionPhase.Performed)
            return;
        
        StoreEvents.CloseStore();
    }
}
