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
            Vector2 newPosition = new Vector2(Random.Range(-30.0f, 30.0f), Random.Range(-25.0f, 25.0f));

            if (Vector2.Distance(newPosition, player.transform.position) > 10.0f)
            {
                Vector3 position = new Vector3(newPosition.x, newPosition.y, 0.0f);

                roundManager.EnemySpawned();
                Instantiate(enemyPrefab, position, Quaternion.identity);
            }
        }
    }
}
