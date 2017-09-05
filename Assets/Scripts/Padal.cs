using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Padal : MonoBehaviour
{
    public float Speed = 5;

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

        _tranform.Translate(new Vector3(input * Speed * Time.deltaTime, 0, 0));
	}
}
