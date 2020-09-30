using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.CompareTag("Enemy"))
        {
            coll.gameObject.GetComponent<FirstEnemyScript>().Damage(10);
            Destroy(gameObject);
        }
    }
}
