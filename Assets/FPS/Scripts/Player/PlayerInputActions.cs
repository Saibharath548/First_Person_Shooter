using FPS;
using System;
using UnityEngine;

public class PlayerInputActions : MonoBehaviour
{
    private PlayerFPS playerInput;
    public event EventHandler OnShooting;
    public event EventHandler OnReload;

    private void Start()
    {
        playerInput = new PlayerFPS();
        playerInput.Player.Enable();
        playerInput.Player.Shooting.performed += Shooting_performed;
        playerInput.Player.Reload.performed += Reload_performed;
    }

    private void Reload_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnReload?.Invoke(this,EventArgs.Empty);
    }

    private void Shooting_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnShooting?.Invoke(this, EventArgs.Empty);
    }

    

    public Vector3 NormalisedPlayerInput()
    {
        Vector3 playerMovement = playerInput.Player.Move.ReadValue<Vector3>();
        playerMovement.Normalize();

        return playerMovement;
    }
}
