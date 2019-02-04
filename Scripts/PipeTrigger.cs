///=============================================\\\
///     Title   : PipeTrigger.cs                \\\
///                                             \\\
///     Author  : Peter Phillips                \\\
///                                             \\\
///     Date    : First entry - 11.01.18        \\\
///               Last entry  - 13.01.18        \\\
///                                             \\\
///     Brief   : Lets the pipe fall down when  \\\
///               the player crawls through it. \\\
///=============================================\\\     


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeTrigger : MonoBehaviour
{
    private bool hasFallen = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !hasFallen)
        {
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<AudioSource>().Play();
            hasFallen = true;
        }
    }
}
