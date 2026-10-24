using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject redEnemy;
    public GameObject blueEnemy;
    public GameObject greenEnemy;

    public float spawnInterval = 2f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnInterval);
    }

    void SpawnEnemy()
    {
        int random = Random.Range(0, 3);

        Vector3 spawnPos = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));

        switch (random)
        {
            case 0:
                Instantiate(redEnemy, spawnPos, Quaternion.identity);
                break;

            case 1:
                Instantiate(blueEnemy, spawnPos, Quaternion.identity);
                break;

            case 2:
                Instantiate(greenEnemy, spawnPos, Quaternion.identity);
                break;
        }
    }
}
