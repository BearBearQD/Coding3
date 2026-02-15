using UnityEditor;
using UnityEngine;

public class RandomEnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public Transform center;
    public float spawnRadius = 5f;
    public int numberofObjects = 1;
    public float spawnIntrevals;

    private float spawnTimer = 0f;

    public bool spawnOnStart;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(spawnOnStart)
        {
            SpawnObjects();
        }
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;

        if(spawnTimer >= spawnIntrevals)
        {
            SpawnObjects();
            spawnTimer = 0f;
        }
    }

    void SpawnObjects()
    {
        if (enemy == null || center == null) return;

        

        for (int i = 0; i <numberofObjects; i++)
        {
            Vector3 randomPosition = center.position + Random.insideUnitSphere * spawnRadius;

            randomPosition.y = center.position.y;

            Instantiate(enemy, randomPosition, Quaternion.identity);
        }
    }    
}
