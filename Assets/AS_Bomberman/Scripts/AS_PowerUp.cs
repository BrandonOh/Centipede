using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AS_PowerUp : MonoBehaviour
{
    AS_PlayerController player;

    [SerializeField] private Text bombCapacityText;
    [SerializeField] private Text fireSizeText;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<AS_PlayerController>();
    }

    private void Update()
    {
        if (gameObject.name == "BombCapacity")
        {
            bombCapacityText.text = player.BombMaxCapacity.ToString();
        }
        
        if (gameObject.name == "BombCapacity")
        {
            fireSizeText.text = player.BombFireSize.ToString();
        }
    }

}
