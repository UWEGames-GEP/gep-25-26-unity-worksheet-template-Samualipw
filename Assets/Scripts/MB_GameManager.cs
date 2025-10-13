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
    
 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (state == GameState.GAMEPLAY) 
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                state = GameState.PAUSE;
                hasChangedState = true;
            }
        }

        else if (state == GameState.PAUSE)
        {
            if (Input.GetKeyDown(KeyCode.Escape)) 
            {
                state = GameState.GAMEPLAY;
                hasChangedState = true;
            }
        }
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
                    break;
                
                case GameState.PAUSE:
                    Time.timeScale = 0.0f;
                    break;
            }
        }
    }
}
