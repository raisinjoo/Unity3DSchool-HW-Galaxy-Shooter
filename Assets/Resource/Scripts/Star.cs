using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    void Update()
    {
        if(transform.position.x<-9.5)
        {
            Destroy(gameObject);
        }

    }
}
