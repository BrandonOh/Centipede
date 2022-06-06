using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AS_Explosion : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Explosion());
    }

    private IEnumerator Explosion()
    {
        yield return new WaitForSeconds(0.5f);

        Destroy(gameObject);
    }
}
