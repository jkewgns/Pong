using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void LocalMultiplayer()
    {
        SceneManager.LoadScene(2);
    }

    public void Singleplayer()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Debug.Log("Qutting...");
        Application.Quit();
    }
}
