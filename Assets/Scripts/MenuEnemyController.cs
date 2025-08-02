using UnityEngine;

public class MenuEnemyController : MonoBehaviour
{
    float speed = 0.5f;

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        float step = speed * Time.deltaTime;
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, mousePos, step);
    }
}
