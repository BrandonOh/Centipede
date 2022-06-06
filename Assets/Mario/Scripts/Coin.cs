using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinCount;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            addCoin();
            Destroy(this.gameObject);
        }
    }

    public void addCoin()
    {
        coinCount++;
        if (coinCount > 99)
        {
            coinCount = -100;
        }
        Debug.Log(coinCount);
    }
}
