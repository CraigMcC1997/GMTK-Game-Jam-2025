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
            // TODO: FIX !! This slows down the creation of enemies, needs to be on a fixed timer instead
            float randomiser = UnityEngine.Random.Range(0, 1000);

            if (randomiser < 7) // Adjust the spawn rate as needed
            {
                Vector2 newPosition = new Vector2(Random.Range(-15.0f, 15.0f), Random.Range(-9.0f, 9.0f));

                if (Vector2.Distance(newPosition, player.transform.position) > 10.0f)
                {
                    Vector3 position = new Vector3(newPosition.x, newPosition.y, 0.0f);

                    roundManager.EnemySpawned();
                    Instantiate(enemyPrefab, position, Quaternion.identity);
                }
            }
        }
    }
}
