using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private int sceneToConrtinue;

    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ContinueGame(){
        sceneToConrtinue = PlayerPrefs.GetInt("SavedScene");

        if (sceneToConrtinue != 0)
            SceneManager.LoadScene(sceneToConrtinue);
        else
            return;
    }

}
