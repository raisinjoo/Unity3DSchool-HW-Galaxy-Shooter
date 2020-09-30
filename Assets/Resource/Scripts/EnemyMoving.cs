using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoving : MonoBehaviour
{
    public float Speed;
    public Vector2 MoveDir;
   
    void Update()
    {
        transform.Translate(MoveDir*Time.deltaTime*Speed);
    }
}
