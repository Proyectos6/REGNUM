using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool JuegoPausado = false;
    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(JuegoPausado)
            {
                Reanudar();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Reanudar ()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        JuegoPausado = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true); 
        Time.timeScale = 0f; 
        JuegoPausado = true; 
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
