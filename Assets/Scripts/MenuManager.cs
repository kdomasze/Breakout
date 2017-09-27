using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("main");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("menu");
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("credits");
    }
}
