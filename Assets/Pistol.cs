// This script is a simple gun implementation that allows the player to shoot bullets.
// It handles the shooting logic, bullet count, and bullet refilling when the player collides with a bullet pack.
// The gun is controlled by the left mouse button, and the player can shoot up to 3 bullets.
// When a bullet pack is collected, the gun's bullet count is refilled to the maximum.

using UnityEngine;

public class Pistol : MonoBehaviour
{
    public Transform gunPoint; // Reference to the GunPoint
    public int maxBullets = 3; // Maximum bullets the gun can hold
    private int currentBullets; // Current bullets available
    public float fireRate = 0.1f; // Time interval between shots
    private float nextFireTime = 0f; // Time when the gun can fire next
    public GameObject bullet;
    public int bulletsPerTap;

    public Camera fpsCam;
    public Transform attackPoint;

    public void Start()
    {
        currentBullets = maxBullets; // Initialize bullets to max
    }

    public void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime && currentBullets > 0)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    public void Shoot()
    {
        // Logic to instantiate and shoot a bullet from gunPoint
        currentBullets--;
        Debug.Log("Bullet shot! Bullets left: " + currentBullets);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BulletPack"))
        {
            currentBullets = maxBullets;
            Debug.Log("Bullets refilled!");
        }
    }
}
