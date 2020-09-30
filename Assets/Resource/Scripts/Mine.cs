using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public GameObject Ship;
    public float distToActive;
    public float Speed;
    public SoundManager sm;
    void Start()
    {
        Ship= GameObject.Find("ship");
        sm = GameObject.Find("Gamezone").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position,Ship.transform.position) <= distToActive)
        {
            transform.position = Vector2.MoveTowards(transform.position,Ship.transform.position,Time.deltaTime*Speed);
        }
         if(Vector2.Distance(transform.position,Ship.transform.position) <= 1f)
        {
            Ship.GetComponent<ShipMoving>().Damage(3);
            Destroy(gameObject);
            sm.PlaySound(0);
        }
    }
     void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.CompareTag("PlayerBullet"))
        {
            Destroy(gameObject);
            Destroy(coll.gameObject);
        }
    }
}
