using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOShoot : MonoBehaviour
{
    public Transform shootPoint;

    public GameObject bulletPrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
    }
}
