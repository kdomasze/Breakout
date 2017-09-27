using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Action OnOutOfBounds;

    public float IntialSpeed = 5;

    public float BallWaitTime = 1.5f;

    private float _maxSpeed;
    private float _collisionFixSensitivity;

    private Rigidbody2D _rigidbody;
    private Transform _transform;

	// Use this for initialization
	void Start ()
	{
	    _maxSpeed = IntialSpeed;
        _collisionFixSensitivity = _maxSpeed / 2f;

        _rigidbody = GetComponent<Rigidbody2D>();
	    _transform = GetComponent<Transform>();

	    OnOutOfBounds += Reset;

        Reset();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        _collisionFixSensitivity = _maxSpeed / 2f;

        if (_rigidbody.velocity.magnitude > _maxSpeed)
        {
            _rigidbody.velocity = _rigidbody.velocity.normalized * _maxSpeed;
        }
    }

    void OnDestroy()
    {
        GameManager.OnNewLevel -= Reset;
    }

    public void Reset()
    {
        StartCoroutine(ResetCoroutine());
    }

    IEnumerator ResetCoroutine()
    {
        _transform.position = new Vector3(0, 0);
        _rigidbody.velocity = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(BallWaitTime);
        _rigidbody.velocity = new Vector3(IntialSpeed, IntialSpeed, 0);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Collided with: " + col.gameObject.tag);

        if (col.gameObject.CompareTag("Brick"))
        {
            col.gameObject.GetComponent<Piece>().OnHit();
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (_rigidbody.velocity.x >= -_collisionFixSensitivity && _rigidbody.velocity.x <= 0f)
        {
            _rigidbody.velocity = new Vector2(-IntialSpeed, _rigidbody.velocity.y);
        }
        else if (_rigidbody.velocity.x <= _collisionFixSensitivity && _rigidbody.velocity.x > 0f)
        {
            _rigidbody.velocity = new Vector2(IntialSpeed, _rigidbody.velocity.y);
        }

        if (_rigidbody.velocity.y >= -_collisionFixSensitivity && _rigidbody.velocity.y <= 0f)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, -IntialSpeed);
        }
        else if (_rigidbody.velocity.y <= _collisionFixSensitivity && _rigidbody.velocity.y > 0f)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, IntialSpeed);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered on: " + other.gameObject.tag);

        if (other.gameObject.CompareTag("Game Over"))
        {
            OnOutOfBounds.Invoke();
        }
    }
}
