using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameObject Player;
    float speed = 2.7f;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, Player.transform.position, step);
    }
}
