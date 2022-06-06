using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOBullet : MonoBehaviour
{
    public float speed = 20f;
    public float destroyTime = 3f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;
    }
    void Update()
    {
        Destroy(gameObject, destroyTime);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        BOMushroomEnv env = hitInfo.GetComponent<BOMushroomEnv>();
        BOCentipedeBody enemy = hitInfo.GetComponent<BOCentipedeBody>();
        if (env != null)
        {
            env.TakeDamage();
            Destroy(gameObject);
        }
        if (enemy != null)
        {
            Destroy(gameObject);
        }
    }
}
