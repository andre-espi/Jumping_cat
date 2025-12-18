using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum GameState { Ready, Playing, Ended };    //Nos permite saber los estados posibles del juego

public class NewMonoBehaviourScript : MonoBehaviour
{
    public GameState gameState = GameState.Ready;   //creamos una variable para detectar el estado del juego
    public RawImage background, platform;
    public float parallaxSpeed = 0.02f;
    public GameObject uiReady, uiScore;
    
    void Update()
    {
        bool action = Input.GetKeyUp("space") || Input.GetMouseButtonDown(0);

        HandleJump(action);
        HandleCollision();
        UpdateParallax();   //llamado a la funcion 
        UpdateGameState(action);
        HandleExit();

    }

    void HandleJump(bool action)
    {
        if (gameState == GameState.Playing && action && PlayerManager.Instance.grounded)
        {
            PlayerManager.Instance.SetAnimation("PlayerJump");   
        }

    }

    void HandleCollision()
    {
        if (gameState == GameState.Playing && PlayerManager.Instance.enemyCollision)
        {
            gameState = GameState.Ended;
            PlayerManager.Instance.SetAnimation("PlayerDie");
            SpawnManager.Instance.StopSpawn();
            SpeedManager.Instance.StartSpeedIncrease();
        }
    }
    void UpdateGameState(bool action)
    {
        if (gameState == GameState.Ready && action)
        {
            gameState = GameState.Playing;
            uiReady.SetActive(false);
            uiScore.SetActive(true);

            PlayerManager.Instance.SetAnimation("PlayerRun");
            SpawnManager.Instance.StartSpawn();
            SpeedManager.Instance.StartSpeedIncrease();
        }
        else if (gameState == GameState.Ended && action)
        {
            HandleRestart();
        }
    }//El juego iniciara cuando el usuario presione espacio o haga click derecho
    void UpdateParallax()   //Creamos una funcion para mantener buenas practicas 
    {
        if (gameState == GameState.Playing)
        {
            float finalSpeed = parallaxSpeed * Time.deltaTime;
            background.uvRect = new Rect(background.uvRect.x + finalSpeed, 0f, 1f, 1f);
            platform.uvRect = new Rect(platform.uvRect.x + finalSpeed * 4, 0f, 1f, 1f);
        }
    }

    void HandleRestart()
    {
        SpeedManager.Instance.ResetSpeed();
        SceneManager.LoadScene("MainMenu");
    }

    void HandleExit()
    {
        if (Input.GetKeyDown("escape")) Application.Quit();
    }
}
