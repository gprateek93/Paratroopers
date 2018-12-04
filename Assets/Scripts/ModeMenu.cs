using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ModeMenu : MonoBehaviour {

    public void Classic()
    {
        //Add the logic to choose btwn two modes.
        //Use the build index
        SceneManager.LoadScene("Level-1");
    }

    public void Enhanced()
    {
        //Add the logic to choose btwn two modes.
        //Use the build index
        SceneManager.LoadScene("Level-2");
    }
}
