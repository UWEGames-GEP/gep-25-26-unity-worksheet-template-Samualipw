using UnityEngine;




public enum GameState
{
    GAMEPLAY,
    PAUSE
}




public class MB_GameManager : MonoBehaviour
{


    public GameState state = GameState.GAMEPLAY;

    bool hasChangedState = false;

    public GameObject inventory;

    
    
    
    
    
    
 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void LateUpdate()
    {
        if (hasChangedState) 
        {
            hasChangedState = false;

            switch (state) 
            {
                case GameState.GAMEPLAY:
                    Time.timeScale = 1.0f;
                    inventory.gameObject.SetActive(false);
                    Cursor.lockState = CursorLockMode.Locked;
                    break;
                
                case GameState.PAUSE:
                    Time.timeScale = 0.0f;
                    inventory.gameObject.SetActive(true);
                    Debug.Log("Test");
                    Cursor.lockState = CursorLockMode.None;
                    break;
            }
        }


    }

    public void TogglePause() 
    {
        if (state == GameState.GAMEPLAY)
        {
           
            state = GameState.PAUSE;
            hasChangedState = true;
            
        }

        else if (state == GameState.PAUSE)
        {
            
            state = GameState.GAMEPLAY;
            hasChangedState = true;
            
        }
    }



}
