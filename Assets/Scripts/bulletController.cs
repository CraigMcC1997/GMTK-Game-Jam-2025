using UnityEngine;

public class bulletController : MonoBehaviour
{
    Vector3 mousePos;

    public float force = 5.0f;

    RoundManager roundManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        roundManager = FindFirstObjectByType<RoundManager>().GetComponent<RoundManager>();

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir = mousePos - transform.position;
        Vector3 rotate = transform.position - mousePos;
        rigidbody.linearVelocity = new Vector2(dir.x, dir.y).normalized * force;
        float rot_z = Mathf.Atan2(rotate.y, rotate.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z + 90.0f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            roundManager.EnemyKilled(); 
            Destroy(gameObject);
        }
    }
}
