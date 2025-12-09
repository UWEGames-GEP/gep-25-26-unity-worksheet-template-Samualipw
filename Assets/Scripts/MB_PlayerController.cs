using UnityEngine;
using StarterAssets;
using UnityEngine.InputSystem;

public class MB_PlayerController : ThirdPersonController
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public MB_GameManager gameManager;
    private void OnPause(InputValue value)
    {
        if (value.isPressed) 
        {
            gameManager.TogglePause();
        }
    }



    
}
