using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnerScript : MonoBehaviour
{
    [SerializeField]private GameObject objectToSpawn;
    [SerializeField]private Transform[] spawnPoints;

    [SerializeField] private float spawnInterval = 0.5f;
    private float timer; 

    void Start()
    {
        timer = spawnInterval;
        SpawnObject(); 
    }

    void Update()
    {
       
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            SpawnObject();
            timer = spawnInterval;
        }
    }

    void SpawnObject()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];

        GameObject spawnedObject = Instantiate(objectToSpawn, spawnPoint.position, Quaternion.identity);
        Destroy(spawnedObject, 4f);
    }
}