using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Obstacle : MonoBehaviour
{
    public UnityEvent OnPlayerHit;
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnPlayerHit?.Invoke();
        }
    }
}
