﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffMoving : MonoBehaviour
{
    public float Speed;
    public Vector2 dir;
    void Update()
    {
        transform.Translate(dir*Speed*Time.deltaTime,Space.World);
    }
}
