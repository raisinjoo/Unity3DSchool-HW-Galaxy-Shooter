using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public GameObject sfx;
    public AudioClip[] ac;
    public void PlaySound(int soundNum)
    {
        GameObject s = Instantiate(sfx,Vector2.zero,Quaternion.identity) as GameObject;
        AudioSource asr = s.GetComponent<AudioSource>();
        asr.clip = ac[soundNum];
        asr.Play();
        Destroy(s,ac[soundNum].length);

    }

}
