using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
       public GameObject ship;
    public Image[] images;

    void Update()
    {
        switch(ship.gameObject.GetComponent<ShipMoving>().maxHit)
        {
            case 0:
            LifesChange(0); break;
            case 1: 
            LifesChange(1); break;
            case 2:
            LifesChange(2); break;
            case 3:
            LifesChange(3); break;
            case 4:
            LifesChange(4); break;
            case 5:
            LifesChange(5); break;
            case 6:
            LifesChange(6); break;
            case 7:
            LifesChange(7); break;
            case 8:
            LifesChange(8); break;
            case 9:
            LifesChange(9); break;
            case 10:
            LifesChange(10); break;
        }
    }
    void LifesChange(int cnt)
    {
        if(cnt!=0)
        {
            for(int i=0;i<cnt;i++)
            {
                images[i].enabled = true;
            }
            if(cnt<10)
            {
                for(int i=cnt;i<=9;i++)
                {
                    images[i].enabled = false;
                }
            }
        }
        else for(int i=0;i<=9;i++)
        {
            images[i].enabled =false;
        }

    }
}
