using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void Play()
    {
        if (PlayerPrefs.HasKey("Level"))
            SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));
        else
            SceneManager.LoadScene(PlayerPrefs.GetInt("Level") + 1);
    }

    public void Quit()
    {
        Application.Quit(); 
    }
}
