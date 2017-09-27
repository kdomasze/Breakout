using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Action OnNewLevel;
    public static Action OnGameOver;
    public static Action OnGameWin;

    public GameObject Brick;
    public GameObject Ball;

    public int PointsPerBrick;
    public int StartingBalls;
    
    public int StartingLevel;

    private int _currentScore;
    private int _currentBalls;

    private bool _gameOver;

    private int _currentLevel;
    private int _numberOfLevels;
    private int _generatedLevel;

    private int _piecesRemaining;

    private readonly int[,,] _pieceMap =
    {
        {
            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0},
            {0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0},
            {0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0}
        },
        {
            {0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0},
            {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0},
            {0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0},
            {0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0}
        }
    };

	// Use this for initialization
	void Start ()
	{
	    Initialize();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!_gameOver)
        {
            if (_generatedLevel != _currentLevel)
            {
                GenerateLevel();
                _generatedLevel = _currentLevel;
            }

            if (_currentBalls == 0)
            {
                Destroy(GameObject.FindGameObjectWithTag("Ball"));
                Destroy(GameObject.FindGameObjectWithTag("Padal"));
                OnGameOver.Invoke();
    
                _gameOver = true;
            }

            if (_piecesRemaining == 0)
            {
                OnNewLevel.Invoke();
                _currentLevel++;
            }

            if (_currentLevel == _numberOfLevels)
            {
                Destroy(GameObject.FindGameObjectWithTag("Ball"));
                Destroy(GameObject.FindGameObjectWithTag("Padal"));
                OnGameWin.Invoke();

                _gameOver = true;
            }
        }
    }

    public int GetCurrentScore()
    {
        return _currentScore;
    }

    public int GetCurrentBalls()
    {
        return _currentBalls;
    }

    private void Initialize()
    {
        _currentLevel = StartingLevel;
        _numberOfLevels = 2;
        _generatedLevel = -1;

        _gameOver = false;

        Piece.OnDestroy += () => _currentScore += PointsPerBrick;
        Piece.OnDestroy += () => _piecesRemaining--;

        _currentBalls = StartingBalls;
        Ball ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<Ball>();
        ball.OnOutOfBounds += () => _currentBalls -= 1;
        OnNewLevel += ball.Reset;
    }

    private void GenerateLevel()
    {
        GameObject pieceHolder = new GameObject("Brick Holder");

        for (int y = 0; y < 4; y++)
        {
            for (int x = 0; x < 12; x++)
            {
                if (_pieceMap[_currentLevel, y, x] == 1)
                {
                    GameObject pieceInstance = Instantiate(Brick);
                    pieceInstance.transform.position = new Vector3((x * 1.25f), (y * -0.75f)); // Magic offset numbers

                    pieceInstance.transform.parent = pieceHolder.transform;

                    _piecesRemaining++;
                }
            }
        }

        pieceHolder.transform.position = new Vector3(-6.9f, 3.5f); // More magic offset numbers
    }
}
