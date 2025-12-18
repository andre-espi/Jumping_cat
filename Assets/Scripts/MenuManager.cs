using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Llamado por el botón "Play"
    public void Jugar()
    {
        SceneManager.LoadScene("Main");
    }
    
    // Llamado por el botón "Salir"
    public void Salir()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}
