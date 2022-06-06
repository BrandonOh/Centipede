using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AS_BreakableBlock : MonoBehaviour
{
    [SerializeField] Items[] items;
    private int randomNumber = 0;

    private void Start()
    {
        randomNumber = Random.Range(0, 100);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Explosion"))
        {
            DropItem();
            Destroy(gameObject);
        }
    }

    private void DropItem()
    {
        Debug.Log("My Random Number: " + randomNumber);

        foreach (var item in items)
        {
            if (randomNumber <= item.dropProbability)
            {
                Debug.Log("Drop Powerup: "+ item);
                Instantiate(item.item, transform.position, Quaternion.identity);

                return;
            }
            else
            {
                randomNumber -= item.dropProbability;
            }
        }
    }
}
[System.Serializable]
public struct Items
{
    public GameObject item;
    public int dropProbability;
}
