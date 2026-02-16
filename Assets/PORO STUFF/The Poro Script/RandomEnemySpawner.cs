using UnityEditor;
using UnityEngine;

public class RandomEnemySpawner : MonoBehaviour
{
    // Getting the Gameobject for the enemy
    public GameObject enemy;

    //Finding the center of the world to base the spawning off of 
    public Transform center;

    //Radius to spawn in
    public float spawnRadius = 5f;

    //Amount of enemies to spawn
    public int numberofObjects = 1;

    // How often to spawn 
    public float spawnIntrevals;

    //spawn timer tic up
    private float spawnTimer = 0f;

    //Should I spawn in the start
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
        //adding time to the timer
        spawnTimer += Time.deltaTime;

        //if the timer is greater then or equal to the set spawn time
        if(spawnTimer >= spawnIntrevals)
        {
            //Spawn some objects
            SpawnObjects();
            // then set the spawner time to 0, to reset the timer
            spawnTimer = 0f;
        }
    }

    void SpawnObjects()
    {

        //Checking if the center and the enemy arent null
        if (enemy == null || center == null) return;

        
        // making a for loop to spawn in enemy, the function for spawning all of them in
        for (int i = 0; i <numberofObjects; i++)
        {
            //Creating a random position for the enemy to spawn in, using random inside unit spheres, which just does a random in a sphere range
            Vector3 randomPosition = center.position + Random.insideUnitSphere * spawnRadius;

            // Making sure the position is equal to center on the Y axis
            randomPosition.y = center.position.y;

            // Spawning in the enemy in the random position that was set earlier
            Instantiate(enemy, randomPosition, Quaternion.identity);
        }
    }    
}
