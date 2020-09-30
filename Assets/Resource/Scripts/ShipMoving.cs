using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ShipMoving : MonoBehaviour
{
    public float Speed;
    public float minY;
    public float maxY;
    public float minX;
    public float maxX;
    
    public GameObject bullet;
    public GameObject rocket;
    public int countRocket;
    public float shootDelay;
    public int maxHit;
    public Text uirocket;
    public Transform[] shootPoints;
    public bool isFire;
    public bool isReadyToShoot;
    private bool isDead=false;
    public SoundManager sm;
    public int PlayerDamage;
    public int coin;
    public Text CoinScr; 
   
    public void Move(Vector2 dir)

    {
        transform.Translate(dir*Time.deltaTime*Speed);
    }
    void Start()
    {
        isReadyToShoot=true;
        isFire=false;
    }
    void Update()
    {
        uirocket.text = Convert.ToString(countRocket);
        CoinScr.text = Convert.ToString(coin);
        Vector2 curPos = transform.localPosition;
        curPos.y = Mathf.Clamp(transform.localPosition.y,minY,maxY);
        curPos.x = Mathf.Clamp(transform.localPosition.x,minX,maxX);
        transform.localPosition=curPos;

        if(isFire&&isReadyToShoot)
        {
            Shoot();
        }
        if(maxHit==0&&!isDead)
        {
            Boom();
            sm.PlaySound(0);
        }

    }
       void Boom()
    {
        isDead=true;
        Destroy(gameObject);

    }
    void Shoot()
    {
        foreach(Transform sp in shootPoints)
            {
                GameObject b = Instantiate(bullet,sp.position,Quaternion.identity) as GameObject;
                Destroy(b,10);
                if(sp == shootPoints[shootPoints.Length-1])
                {
                    StartCoroutine(Shoot_Delay());
                }
                sm.PlaySound(2);
            }
            
        if(isReadyToShoot=false)
        {
            StartCoroutine(Shoot_Delay());
        }
    }
    IEnumerator Shoot_Delay()
    {
        isReadyToShoot=false;
        yield return new WaitForSeconds(shootDelay);
        isReadyToShoot = true;
    }
    public void Fire(bool Fire)
    {
        isFire=Fire;
    }
    public void Damage(int dmg)
    {
        maxHit -= dmg;
        if(maxHit<=0)
        {
            maxHit=0;
        }
        
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.CompareTag("EnemyBullet"))
        {
            Damage(1);
            Destroy(coll.gameObject);
        }
        if(coll.gameObject.CompareTag("Coin"))
        {
            Destroy(coll.gameObject);
            sm.PlaySound(3);
            coin++;
        }
    }
    public void RocketShoot()
    {
        if (countRocket>0)
        {
            GameObject r = Instantiate(rocket,transform.position,Quaternion.identity) as GameObject;
            countRocket--;
        }
        sm.PlaySound(1);
    }
 

}
