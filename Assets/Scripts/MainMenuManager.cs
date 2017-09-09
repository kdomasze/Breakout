using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Button PlayButton;

    void Start()
    {
        PlayButton.onClick.AddListener((delegate() { LoadScene("main");  }));
    }

    private void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
