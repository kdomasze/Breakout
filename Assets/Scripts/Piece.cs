using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public static Action OnDestroy; 
    public void OnHit()
    {
        OnDestroy.Invoke();
        Destroy(gameObject);
    }
}
