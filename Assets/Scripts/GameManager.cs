using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Piece;

    private int[,] _pieceMap =
    {
        {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
        {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0},
        {0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0},
        {0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0}
    };

	// Use this for initialization
	void Start ()
	{
	    GameObject pieceHolder = new GameObject("Piece Holder");

        for (int y = 0; y < 4; y++)
        {
            for (int x = 0; x < 12; x++)
            {
                if (_pieceMap[y, x] == 1)
                {
                    GameObject pieceInstance = Instantiate(Piece);
                    pieceInstance.transform.position = new Vector3((x * 1.25f), (y * -0.75f));

                    pieceInstance.transform.parent = pieceHolder.transform;
                }
            }
        }

        pieceHolder.transform.position = new Vector3(-6.9f, 3.5f);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
