using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 9;
    public GameObject powerupPrefab;
    public int enemiesInWave = 0;
    public int enemyCount;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsByType<EnemyController>(FindObjectsSortMode.None).Length;

        if (enemyCount == 0)
        {
            enemiesInWave++;
            SpawnWave(enemiesInWave);
            PowerupGenerator();
        }
    }

    private Vector3 GetRandomPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnVector = new Vector3(spawnPosX, 0.3f, spawnPosZ);

        return spawnVector;
    }

    private void PowerupGenerator()
    {
        Instantiate(powerupPrefab, GetRandomPosition() + new Vector3(0, 0.35f, 0), powerupPrefab.transform.rotation);
    }

    private void SpawnWave(int enemiesInWave)
    {
        for(int i = 0; i < enemiesInWave; i++)
        {
            Instantiate(enemyPrefab, GetRandomPosition(), enemyPrefab.transform.rotation);
        }
    }
}