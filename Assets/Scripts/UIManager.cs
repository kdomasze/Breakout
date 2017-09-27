using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(GameManager))]
public class UIManager : MonoBehaviour
{
    public Text ScoreText;
    public Text BallsRemainingText;
    public GameObject GameOverOverlay;
    public GameObject GameWinOverlay;

    private GameManager _gameManager;

	// Use this for initialization
	void Start ()
	{
	    _gameManager = GetComponent<GameManager>();

	    GameManager.OnGameOver += () => ShowGameOver();
	    GameManager.OnGameWin += () => ShowGameWin();
    }
	
	// Update is called once per frame
	void Update ()
	{
	    ScoreText.text = "Score: " + _gameManager.GetCurrentScore();
	    BallsRemainingText.text = "Balls: " + _gameManager.GetCurrentBalls();
	}

    private void ShowGameOver()
    {
        Transform uiGroup = GameObject.FindObjectOfType<Canvas>().transform;
        var gameOverOverlay = Instantiate(GameOverOverlay, uiGroup);

        gameOverOverlay.GetComponentInChildren<Button>().onClick.AddListener((delegate () { SceneManager.LoadScene("menu"); }));
    }

    private void ShowGameWin()
    {
        Transform uiGroup = GameObject.FindObjectOfType<Canvas>().transform;
        var gameOverOverlay = Instantiate(GameWinOverlay, uiGroup);

        gameOverOverlay.GetComponentInChildren<Button>().onClick.AddListener((delegate () { SceneManager.LoadScene("menu"); }));
    }
}
