using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private float minSpawnInterval = 1f;
    [SerializeField] private float maxSpawnInterval = 5f;
    [SerializeField] private float minSpawnHeight = 3f; 
    [SerializeField] private float maxSpawnHeight = -3f; 

    private Camera mainCamera; 

    private void Awake()
    {
        mainCamera = Camera.main; 
    }

    private void Start()
    {
        StartCoroutine(SpawnBonus());
    }

    private IEnumerator SpawnBonus()
    {
        while (true)
        {
            Vector2 spawnPosition = mainCamera.ViewportToWorldPoint(new Vector2(1, 0.5f));

            float spawnHeight = Random.Range(minSpawnHeight, maxSpawnHeight);
            spawnPosition.y = spawnHeight;
            
            Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
            float spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
