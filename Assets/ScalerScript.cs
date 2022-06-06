using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalerScript : MonoBehaviour
{
    // These are words
    // Start is called before the first frame update
    void Start()
    {
        float width = Screen.width;
        transform.localScale = Vector3.one * (width / 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
