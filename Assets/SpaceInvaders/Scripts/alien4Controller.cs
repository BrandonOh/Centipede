using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alien4Controller : MonoBehaviour
{
    public Transform startingPoint;
    public GameObject alienPreFab;

    public float speed = 150.0f;
    private float interval = 15.0f;

    //Update is called once per frame
    void Update()
    {
        if (Time.time > interval) //every 10 seconds generate new alien
        {
            Generate();
            interval += Time.time;
           
        }
    }

    //function to instantiate alien4 object and translate to left
    void Generate()
    {
        GameObject alien = Instantiate(alienPreFab, startingPoint.position, startingPoint.rotation); //creating alien
        Rigidbody2D rb = alien.GetComponent<Rigidbody2D>();
        rb.AddForce(-startingPoint.right * speed, ForceMode2D.Impulse); //move left at high velocity
    }
}
