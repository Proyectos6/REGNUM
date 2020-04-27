using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public Canvas pauseCanvas;
    bool activarPausa;
    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        pauseCanvas.enabled = false;

        gm = FindObjectOfType<GameManager>();
        gm.paused = activarPausa;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            activarPausa = !activarPausa;
            gm.paused = activarPausa;

            pauseCanvas.enabled = activarPausa;

        }
      
        
    }
    public void Resume()
    {
        activarPausa = false;
        
    }
    public void Restart()
    {
        SceneManager.LoadScene(1);

    }
    public void Menu()
    {
        SceneManager.LoadScene(0);

    }
    public void Quit()
    {
        Application.Quit();

    }
}
