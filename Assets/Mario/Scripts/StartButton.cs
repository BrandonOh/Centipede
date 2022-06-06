using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
  
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void stopAnimation()
    {
        anim.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        anim.Play("Block_raise", 0, 0.25f);
        stopAnimation();
        anim.enabled = true;
    }
}
