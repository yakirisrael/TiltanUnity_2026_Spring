using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public int amount = 20;
    public float offset = 10;
    public GameObject enemyPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void CreateEnemies()
    {
        Vector3 StartPosition = transform.position;

        for (int i = 0; i < amount; i++)
        {
            CreateEnemy(StartPosition, i);
        }
    }

    private void CreateEnemy(Vector3 StartPosition, int i)
    {
        Vector3 SpawnPosition = new Vector3(
            StartPosition.x + (offset * i),
            StartPosition.y,
            StartPosition.z);

        Instantiate(enemyPrefab, SpawnPosition, Quaternion.identity);
    }

    void Start()
    {
        CreateEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
