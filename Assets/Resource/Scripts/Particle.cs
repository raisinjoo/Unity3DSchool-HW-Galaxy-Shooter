using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Particle : MonoBehaviour
{
    public GameObject fx;
    void OnDestroy()
    {
        GameObject p = Instantiate(fx,transform.position,Quaternion.identity) as GameObject;
        p.GetComponent<ParticleSystem>().Play();
        Destroy(p,p.GetComponent<ParticleSystem>().duration);
    }
}
