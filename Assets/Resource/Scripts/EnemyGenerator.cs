using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject[] Enemyes;
    public float minDelay;
    public float maxDelay;
    public float minY;
    public float maxY;
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Repeat()
    {
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(Random.Range(minDelay,maxDelay));
        Vector2 pos =  new Vector2(transform.position.x,Random.Range(minY,maxY));
        GameObject e = Instantiate(Enemyes[Random.Range(0,Enemyes.Length-1)],pos,Quaternion.identity) as GameObject;
        Repeat();
    }
}
