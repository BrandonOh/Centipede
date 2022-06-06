using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOMushroomEnv : MonoBehaviour
{
    public int health = 4;

    SpriteRenderer mushroomRender;
    public GameObject score;

    public Sprite[] mushroom;

    private void Start()
    {
        score = GameObject.Find("Score");
    }
    public void TakeDamage()
    {
        mushroomRender = gameObject.GetComponent<SpriteRenderer>();

        health--;
        if (health == 4)
        {
            mushroomRender.sprite = mushroom[2];
        }
        if (health == 3)
        {
            mushroomRender.sprite = mushroom[2];
        }
        if (health == 2)
        {
            mushroomRender.sprite = mushroom[1];
        }
        if (health == 1)
        {
            mushroomRender.sprite = mushroom[0];
        }
        if (health <= 0)
        {
            score.GetComponent<BOScore>().AddPoints(10);
            DamageShroom();
        }
    }

    void DamageShroom()
    {
        Destroy(gameObject);
    }
}
