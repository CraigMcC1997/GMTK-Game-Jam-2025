using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    RoundManager roundManager; // Reference to the RoundManager to get max enemies
    public GameObject enemyPrefab;

    void Start()
    {
        roundManager = FindFirstObjectByType<RoundManager>().GetComponent<RoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        spawner();
    }
    
    void spawner()
    {
        if (!roundManager.GetMaxEnemiesReached())
        {
            float spawnX = UnityEngine.Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
            float spawnY = UnityEngine.Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
            Vector3 position = new Vector3(spawnX, spawnY, 0.0f);

            // TODO: FIX !! This slows down the creation of enemies, needs to be on a fixed timer instead
            float randomiser = UnityEngine.Random.Range(0, 1000);

            if (randomiser < 3) // Adjust the spawn rate as needed
            {
                roundManager.EnemySpawned();
                Instantiate(enemyPrefab, position, Quaternion.identity);
            }
        }
    }
}
