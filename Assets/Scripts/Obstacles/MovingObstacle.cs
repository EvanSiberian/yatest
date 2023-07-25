using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovingObstacle : Obstacle
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float verticalSpeed = 0.5f;  
    [SerializeField] private float verticalMovementDistance = 1f; 

    private Camera mainCamera;
    private float leftScreenBoundary;
    private float initialY;
    
    private void OnEnable()
    {
        GameManager.Instance.RegisterObstacle(this);
    }

    private void OnDisable()
    {
        GameManager.Instance.UnregisterObstacle(this);
    }
    
    private void Start()
    {
        mainCamera = Camera.main; 
        leftScreenBoundary = mainCamera.ScreenToWorldPoint(new Vector3(1, 0.5f, mainCamera.transform.position.z)).x;
        initialY = transform.position.y;
    }

    private void Update()
    {
        float newY = initialY + Mathf.Sin(Time.time * verticalSpeed) * verticalMovementDistance;
        
        Vector3 newPosition = new Vector3(transform.position.x + Vector3.left.x * speed * Time.deltaTime, newY, transform.position.z);
        transform.position = newPosition;

        if (transform.position.x < leftScreenBoundary)
        {
            Destroy(gameObject);
        }
    }
}

