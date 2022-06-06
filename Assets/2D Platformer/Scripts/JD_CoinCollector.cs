using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JD_CoinCollector : MonoBehaviour
{
    private float coin = 0;

    public TextMeshProUGUI textCoins;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag == "Coin")
        {
            coin ++;
            textCoins.text = coin.ToString();
            Destroy(other.gameObject);
        }
        if (coin == 3)
        {
            SceneManager.LoadScene(21);
        }
    }
}
