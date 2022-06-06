using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOMushromGenerate : MonoBehaviour
{
    BoxCollider2D area;

    public BOMushroomEnv mushroom;
    public int amount = 25;

    void Awake()
    {
        area = GetComponent<BoxCollider2D>();

    }

    void Start()
    {
        Generate();
    }

    void Generate()
    {
        Bounds bounds = area.bounds;
        for(int i = 0; i < amount; i++)
        {
            Vector2 position = Vector2.zero;
            position.x = Mathf.Round(Random.Range(bounds.min.x, bounds.max.x));
            position.y = Mathf.Round(Random.Range(bounds.min.y, bounds.max.y));

            Instantiate(mushroom, position, Quaternion.identity, transform);
        }
    }
}
