using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovingBonus : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    
    private Camera mainCamera;
    private float leftScreenBoundary;
    
    public UnityEvent OnPlayerTake;
    
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnPlayerTake?.Invoke();
            Destroy(this.gameObject);
        }
    }
    
    private void OnEnable()
    {
        GameManager.Instance.RegisterBonus(this);
    }

    private void OnDisable()
    {
        GameManager.Instance.UnregisterBonus(this);
    }
    
    private void Start()
    {
        mainCamera = Camera.main; 
        leftScreenBoundary = mainCamera.ScreenToWorldPoint(new Vector3(1, 0.5f, mainCamera.transform.position.z)).x;

    }
    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        
        if (transform.position.x < leftScreenBoundary)
        {
            Destroy(gameObject);
        }
    }
}
