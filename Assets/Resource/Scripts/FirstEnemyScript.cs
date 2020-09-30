using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstEnemyScript : MonoBehaviour
{
    public int maxHit;
    public GameObject bullet;
    public float shootDelay;
    public Transform shootPoint;
    public ShipMoving ship;
    private bool isDead=false;
    public SoundManager sm;
    public GameObject coin;
    void Start()
    {
        sm = GameObject.Find("Gamezone").GetComponent<SoundManager>();
        ship = GameObject.Find("ship").GetComponent<ShipMoving>();
        InvokeRepeating("Shoot",2,shootDelay);
    }
    void Update()
    {
        if(maxHit==0&&!isDead)
        {
            Boom();
            sm.PlaySound(0);
            SpawnCoin();
        }
    }
    void Boom()
    {
        isDead=true;
        Destroy(gameObject);
    }
    void SpawnCoin()
    {
        GameObject c = Instantiate(coin,transform.position,Quaternion.identity) as GameObject;
    }
    void Shoot()
    {
        GameObject b = Instantiate(bullet,shootPoint.position,Quaternion.identity) as GameObject;
        Destroy(b,10);
    }
    public void Damage(int dmg)
    {
        maxHit -= dmg;
        if(maxHit<0)
        {
            maxHit=0;
        }
        
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.CompareTag("PlayerBullet"))
        {
            Damage(ship.PlayerDamage);
            Destroy(coll.gameObject);
        }
    }


}
