using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float IntialSpeed = 5;
    private Rigidbody2D _rigidbody;

	// Use this for initialization
	void Start ()
	{
	    _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.velocity = new Vector3(IntialSpeed, IntialSpeed, 0);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
