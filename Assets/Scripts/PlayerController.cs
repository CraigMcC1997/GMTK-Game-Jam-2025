using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    
    Rigidbody2D rb;
    public float moveSpeed = 10.0f;
    float translationX, translationY;

    PlayerManager playerManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerManager = FindFirstObjectByType<PlayerManager>().GetComponent<PlayerManager>();
        moveSpeed = playerManager.getPlayerSpeed();
    }

    void playerMovement()
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
            //check if player reached screen boundaries
            if (screenPos.x > 0)
                translationX = -moveSpeed;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            //check if player reached screen boundaries
            if (screenPos.x < Screen.width)
                translationX = moveSpeed;
        }

        // Make it move it per second instead of per frame
        translationX *= Time.deltaTime;
        translationY *= Time.deltaTime;

        // Move player
        transform.Translate(translationX, translationY, 0);
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement();
    }
}
