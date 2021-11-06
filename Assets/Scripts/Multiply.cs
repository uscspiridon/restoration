using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiply : MonoBehaviour {
    public GameObject moldPrefab;
    public float minSpawnTime;
    public float maxSpawnTime;

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
            Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
            randomDirection.Normalize();
            float radius = transform.localScale.x;
            randomDirection *= radius;
            Vector3 spawnPosition = transform.position + randomDirection;
            Debug.Log("spawnPosition = (" + spawnPosition.x + ", " + spawnPosition.y + ")  randomDirection = " + randomDirection.x + ", " + randomDirection.y + ")");
            // instantiate the prefab
            GameObject newMold = Instantiate(moldPrefab, spawnPosition, Quaternion.identity);
            newMold.transform.parent = transform.parent;
            // reset the timer
            ResetTimer();
        }
    }

    private void ResetTimer() {
        timer = 0f;
        spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
    }
}
