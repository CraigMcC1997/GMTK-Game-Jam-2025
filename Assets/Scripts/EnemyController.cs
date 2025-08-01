using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameObject Player;
    float speed;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        speed = Random.Range(2.0f, 4.0f);
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, Player.transform.position, step);
    }
}
