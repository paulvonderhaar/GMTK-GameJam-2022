using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public InputAction gunControls;

    public float bulletForce=20f;

    private void Awake()
    {

        gunControls.Enable();
    }
    private void onDisable()
    {   Debug.Log("Disabeled");
        gunControls.Disable();
    }

    // Update is called once per frame
    void Update()
    {
         if (Mouse.current.leftButton.wasPressedThisFrame)
         {
            Shoot();
         }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab,firePoint.position, firePoint.rotation);
        Rigidbody2D rb =bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
