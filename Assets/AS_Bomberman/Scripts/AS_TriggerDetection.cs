using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AS_TriggerDetection : MonoBehaviour
{
    AS_PlayerController player;

    private void Start()
    {
        player = transform.GetComponentInParent<AS_PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BreakableBlock"))
        {
            if (transform.name == "LeftTrigger")
            {
                player.PositionTrigger = "Left";
            }
            if (transform.name == "RightTrigger")
            {
                player.PositionTrigger = "Right";
            }
            if (transform.name == "UpTrigger")
            {
                player.PositionTrigger = "Up";
            }
            if (transform.name == "DownTrigger")
            {
                player.PositionTrigger = "Down";
            }
        }
    }
}
