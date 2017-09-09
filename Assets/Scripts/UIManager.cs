using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GameManager))]
public class UIManager : MonoBehaviour
{
    public Text ScoreText;
    public Text BallsRemainingText;

    private GameManager _gameManager;

	// Use this for initialization
	void Start ()
	{
	    _gameManager = GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    ScoreText.text = "Score: " + _gameManager.GetCurrentScore();
	    BallsRemainingText.text = "Balls: " + _gameManager.GetCurrentBalls();
	}

    private void ShowGameOver()
    {

    }
}
