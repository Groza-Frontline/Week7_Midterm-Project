using UnityEngine;

// This class is responsible for spawning random colored enemies
public class EnemySpawner : MonoBehaviour
{
    // Enemy prefabs that will be assigned in the Inspector
    public GameObject redEnemy;
    public GameObject blueEnemy;
    public GameObject greenEnemy;
    
    // Time interval between enemy spawns
    public float spawnInterval = 2f;

    void Start()
    {
        // Continuously call spawn SpawnEnemy() method every spawnInterval seconds
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnInterval);
    }

    // Method to spawn a random enemy at a random position
    void SpawnEnemy()
    {
        // Generate a random number between 0 and 2 to select which enemy to spawn
        int random = Random.Range(0, 3);

        // Generate a random position within a defined range for spawning the enemy
        Vector3 spawnPos = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));

        // Use a switch statement to instantiate the selected enemy prefab at the random position
        switch (random)
        {
            // Instantiate the red enemy prefab
            case 0:
                Instantiate(redEnemy, spawnPos, Quaternion.identity);
                break;

            // Instantiate the blue enemy prefab
            case 1:
                Instantiate(blueEnemy, spawnPos, Quaternion.identity);
                break;

            // Instantiate the green enemy prefab
            case 2:
                Instantiate(greenEnemy, spawnPos, Quaternion.identity);
                break;
        }
    }
}
