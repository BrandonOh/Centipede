using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alienBulletShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    private float nextFire;

    public float bulletForce = 100.0f;

    void Start()
    {
       nextFire = Random.Range(5.0f, 25.0f); //setting random number between 1.0 - 10.0
    }

    // Update is called once per frame
    void Update()
    {
     if(Time.time > nextFire)
        {
            nextFire = Time.time + Random.Range(15.0f, 25.0f); //set it to a different number 
            Shoot(); //call function
        }
    }

    //function to instantiate bullet object and shoot bullet 
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); //creating bullet
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(-firePoint.up * bulletForce, ForceMode2D.Impulse); //flying at high velocity
    }
}
