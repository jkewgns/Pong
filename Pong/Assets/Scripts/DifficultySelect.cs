using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultySelect : MonoBehaviour
{
    public void Easy()
    {
        SceneManager.LoadScene(3);
    }

    public void Normal()
    {
        SceneManager.LoadScene(4);
    }

    public void Hard()
    {
        SceneManager.LoadScene(5);
    }

    public void Impossible()
    {
        SceneManager.LoadScene(6);
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }
}
