using UnityEngine;

public class shootingPointController : MonoBehaviour
{
    private Camera cam;
    private Vector3 mousePos;

    public GameObject bullet;
    public Transform firePoint;
    
    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    void shoot()
    { 
        Instantiate(bullet, firePoint.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float angle = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        if (Input.GetKeyDown(KeyCode.Mouse0))
            shoot();
    }
}
