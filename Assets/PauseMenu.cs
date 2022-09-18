using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool GamePaused = false;
    public EndMenu endMenu;
    public GameObject pauseMenuUI;
    public StartInfo startInfo;

    void Start()
    {
        if (startInfo.isUsed)
        {
            Pause();
        }
    }

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

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        GamePaused = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
