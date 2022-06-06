using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingBullet : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 100.0f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) //when space key is down - call function Shoot()
        {
            Shoot();
        }
        
    }

    //function to instantiate bullet object and shoot bullet 
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); //creating bullet
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse); //flying at high velocity
    }
}
