using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameObject Player;
    float speed = 4.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, Player.transform.position, step);
    }
}
