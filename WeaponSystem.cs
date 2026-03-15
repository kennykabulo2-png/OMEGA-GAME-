using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    // Variables for weapon statistics
    public float range = 100f;
    public float fireRate = 1f;
    public GameObject projectilePrefab;
    public Transform firePoint;

    private float nextTimeToFire = 0f;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        // Instantiate the projectile
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        // Add shooting mechanics, such as applying force and damaging enemies here
        Debug.Log("Shot fired!");
    }
}