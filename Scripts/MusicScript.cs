///=============================================\\\
///     Title   : MusicScript.cs                \\\
///                                             \\\
///     Author  : Peter Phillips                \\\
///                                             \\\
///     Date    : First entry - 13.01.18        \\\
///               Last entry  - 13.01.18        \\\
///                                             \\\
///     Brief   : Plays an assortment of        \\\
///               atmospheric sounds.           \\\
///=============================================\\\     


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    [SerializeField] private AudioClip[] clips;

    private int rand;
    
	void Update ()
    {
        if (!GetComponent<AudioSource>().isPlaying)
        {
            rand = Random.Range(0, 8);
            GetComponent<AudioSource>().clip = clips[rand];
            GetComponent<AudioSource>().Play();
        }
	}
}
