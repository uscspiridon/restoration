using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoldManager : MonoBehaviour {
    public GameObject moldPrefab;
    public float minSpawnTime;
    public float maxSpawnTime;
    public Transform minSpawnPosition;
    public Transform maxSpawnPosition;
    public float spawnClumpRadius;

    private float spawnTime;
    private float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        ResetTimer();
    }

    // Update is called once per frame
    void Update() {
        timer += Time.deltaTime;
        if (timer >= spawnTime) {
            // determine random position
            Vector3 spawnPosition = new Vector3(Random.Range(minSpawnPosition.position.x, maxSpawnPosition.position.x), Random.Range(minSpawnPosition.position.y, maxSpawnPosition.position.y));
            // instantiate first prefab
            GameObject newMold = Instantiate(moldPrefab, spawnPosition, Quaternion.identity);
            newMold.transform.parent = transform;
            for (int i = 1; i < 5; i++) {
                // determine random position
                Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
                randomDirection.Normalize();
                randomDirection *= spawnClumpRadius;
                Vector3 randomPosition = newMold.transform.position + randomDirection;
                Debug.Log("randomPosition = (" + randomPosition.x + ", " + randomPosition.y + ")  randomDirection = " + randomDirection.x + ", " + randomDirection.y + ")");

                // instantiate the prefab
                newMold = Instantiate(moldPrefab, randomPosition, Quaternion.identity);
                newMold.transform.parent = transform;
            }
            
            // reset the timer
            ResetTimer();
        }
    }

    private void ResetTimer() {
        timer = 0f;
        spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
    }
}