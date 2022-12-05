EnemySpawnManager:

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManger : MonoBehaviour
{

    public GameObject[] enemyPrefabs;
    [SerializeField]
    private float spawnRangeX = 11.0f;
    [SerializeField]
    private float spawnPosZ;

    private float startDelay = 2f;
    private float spawnInterval = 2f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", startDelay, spawnInterval);
    }

    void SpawnRandomEnemy()
    {
        // Generate an X position to spawn at
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX),0,spawnPosZ);

        int enemyIndex = Random.Range(0,enemyPrefabs.Length);
        //Spawn the enemy indexed from the array
        Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);
    }
}  

DetectCollision:

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject); // Destroy this game object
        Destroy(other.gameObject); // Destoyr the other game object it hits
    }
}
