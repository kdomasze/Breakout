using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text ScoreText;
    public int PointsPerBrick;
    private int score = 0;

	// Use this for initialization
	void Start ()
	{
	    Piece.OnDestroy += () => score += PointsPerBrick;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    ScoreText.text = "Score: " + score;
	}
}
