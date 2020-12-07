using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    private PlayerHealth playerHealth;

    public GameObject enemy;

    private float spawnTime = 3f;
    
    [SerializeField]
    private Transform[] spawnPoints;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        if (playerHealth.currentHealth <= 0)
        {
            return;
        }

        int spawnPointIndex = UnityEngine.Random.Range(0, spawnPoints.Length);

        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
    
    
}
