using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    RoundManager roundManager; // Reference to the RoundManager to get max enemies
    public GameObject enemyPrefab;

    GameObject player; // Reference to the player object

    void Start()
    {
        roundManager = FindFirstObjectByType<RoundManager>().GetComponent<RoundManager>();
        player = FindFirstObjectByType<PlayerManager>().GetComponent<PlayerManager>().gameObject;
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
            float randomiser = UnityEngine.Random.Range(0, 1000);

            if (randomiser < 3) // Adjust the spawn rate as needed
            {
                float spawnX = UnityEngine.Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
                float spawnY = UnityEngine.Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);

                if (Vector3.Distance(new Vector3(spawnX, spawnY, 0), player.transform.position) < 10.0f)
                {
                    // If the spawn position is too close to the player, move the spawn position further away
                    spawnX += UnityEngine.Random.Range(-10.0f, 10.0f);
                    spawnY += UnityEngine.Random.Range(-10.0f, 10.0f);
                }

                Vector3 position = new Vector3(spawnX, spawnY, 0.0f);

                // TODO: FIX !! This slows down the creation of enemies, needs to be on a fixed timer instead
                roundManager.EnemySpawned();
                Instantiate(enemyPrefab, position, Quaternion.identity);
            }
        }
    }
}
