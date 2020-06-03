using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

   // public string nameNextScene;
    // Start is called before the first frame update
    

    public void CambiarEscena(string nameNextScene)
    { 
        if(nameNextScene != "Exit")
        {
            SceneManager.LoadScene(nameNextScene);
        }
        else
        {
            Application.Quit();
        }
    }
    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
