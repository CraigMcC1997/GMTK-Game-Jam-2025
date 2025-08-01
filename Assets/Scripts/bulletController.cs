using UnityEngine;

public class bulletController : MonoBehaviour
{
    Vector3 mousePos;

    public float force = 70.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject player = FindFirstObjectByType<PlayerManager>().GetComponent<PlayerManager>().gameObject;
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir = mousePos - transform.position;
        Vector3 rotate = transform.position - mousePos;
        rigidbody.linearVelocity = new Vector2(dir.x, dir.y).normalized * force;
        float rot_z = Mathf.Atan2(rotate.y, rotate.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z + 90.0f);
    }

    void Update()
    {
        // Destroy the bullet after 4 seconds to prevent memory leaks
        Destroy(gameObject, 4.0f);
    }
}
