using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float IntialSpeed = 5;

    private Rigidbody2D _rigidbody;
    private Transform _transform;

	// Use this for initialization
	void Start ()
	{
	    _rigidbody = GetComponent<Rigidbody2D>();
	    _transform = GetComponent<Transform>();

        Reset();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void Reset()
    {
        _transform.position = new Vector3(0, 0);
        _rigidbody.velocity = new Vector3(IntialSpeed, IntialSpeed, 0);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Collided with: " + col.gameObject.tag);

        if (col.gameObject.CompareTag("Piece"))
        {
            col.gameObject.GetComponent<Piece>().OnHit();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered on: " + other.gameObject.tag);

        if (other.gameObject.CompareTag("Game Over"))
        {
            this.Reset();
        }
    }
}
