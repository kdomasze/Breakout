using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text ScoreText;
    public Text BallsRemainingText;

    public int PointsPerBrick;
    public int StartingBalls;

    private int _currentScore;
    private int _currentBalls;

	// Use this for initialization
	void Start ()
	{
        Piece.OnDestroy += () => _currentScore += PointsPerBrick;

	    _currentBalls = StartingBalls;
	    Ball.OnGameOver += () => _currentBalls -= 1;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    ScoreText.text = "Score: " + _currentScore;
	    BallsRemainingText.text = "Balls: " + _currentBalls;
	}
}
