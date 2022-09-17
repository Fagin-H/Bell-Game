using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool GamePaused = false;
    public EndMenu endMenu;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (!endMenu.isOver && Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }


    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        GamePaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        GamePaused = true;
    }

    public void LoadMenu()
    {
        Debug.Log("Loading menu");
        //SceneManager.LoadScene()
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game");
        Application.Quit();
    }
}
