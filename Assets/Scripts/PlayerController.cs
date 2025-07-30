using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeed;
    float translationX, translationY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveSpeed = 10.0f;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            //check if player reached screen boundaries
            if (screenPos.y < Screen.height)
                translationY = moveSpeed;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            //check if player reached screen boundaries
            if (screenPos.y > 0)
                translationY = -moveSpeed;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (screenPos.x > 0)
                translationX = -moveSpeed;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (screenPos.x < Screen.width)
                translationX = moveSpeed;
        }
        
        // Make it move it per second instead of per frame
        translationX *= Time.deltaTime;
        translationY *= Time.deltaTime;

        // Move translation along the object's y-axis
        transform.Translate(translationX, translationY, 0);
    }
}
