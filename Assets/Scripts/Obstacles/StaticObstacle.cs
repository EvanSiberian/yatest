using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticObstacle : Obstacle
{
    private void Start()
    {
        GameManager.Instance.RegisterObstacle(this);
    }
    private void OnEnable() 
    {
        UpdateSize();
        ScreenSizeWatcher.OnScreenSizeChanged += UpdateSize;
    }

    private void OnDisable() 
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.UnregisterObstacle(this);
        }
        ScreenSizeWatcher.OnScreenSizeChanged -= UpdateSize;
        
    }
    
    private void UpdateSize() 
    {
        float cameraWidth = Camera.main.orthographicSize * 2.0f * Screen.width / Screen.height;
        transform.localScale = new Vector3(cameraWidth, transform.localScale.y, transform.localScale.z);
    }
}
