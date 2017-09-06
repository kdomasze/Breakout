using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Padal : MonoBehaviour
{
    public float Speed = 5;

    public Transform leftWall;
    public Transform rightWall;

    private Transform _tranform;

	// Use this for initialization
	void Start ()
	{
	    _tranform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    float input = Input.GetAxisRaw("Horizontal");
	    float deltaX = input * Speed * Time.deltaTime;

	    float leftBoundPosition = _tranform.position.x - (_tranform.localScale.x / 2) - deltaX;
	    float rightBoundPosition = _tranform.position.x + (_tranform.localScale.x / 2) + deltaX;

        if (Mathf.Sign(input) == -1 && !(leftBoundPosition <= leftWall.position.x))
	    {
	        _tranform.Translate(new Vector3(deltaX, 0, 0));
	    }

        if (Mathf.Sign(input) == 1 && !(rightBoundPosition >= rightWall.position.x))
	    {
	        _tranform.Translate(new Vector3(deltaX, 0, 0));
        }

	}
}
