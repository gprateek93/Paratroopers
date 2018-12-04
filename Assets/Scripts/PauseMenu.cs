using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour {

    public static bool PauseStatus = false;
    public GameObject pauseMenuRef;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
          if (PauseStatus)
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
        pauseMenuRef.SetActive(false);
        Time.timeScale = 1f;
        PauseStatus = false;
    }

    void Pause()
    {
        pauseMenuRef.SetActive(true);
        Time.timeScale = 0f;
        PauseStatus = true;
    }

    public void Menu()
    {
        Debug.Log("MainMenu!");
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
