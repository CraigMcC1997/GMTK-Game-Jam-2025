using UnityEngine;

public class shootingPointController : MonoBehaviour
{
    private Camera cam;

    public GameObject bullet;
    public Transform firePoint;
    AudioSource gunFire;

    void Start()
    {
        gunFire = GetComponent<AudioSource>();
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    void shoot()
    {
        gunFire.Play();
        Instantiate(bullet, firePoint.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float angle = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        if (Input.GetKeyDown(KeyCode.Mouse0))
            shoot();
    }
}
