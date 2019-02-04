///=============================================\\\
///     Title   : VentTrigger.cs                \\\
///                                             \\\
///     Author  : Peter Phillips                \\\
///                                             \\\
///     Date    : First entry - 10.01.18        \\\
///               Last entry  - 13.01.18        \\\
///                                             \\\
///     Brief   : Opens the vent once the door  \\\
///               has closed and the player is  \\\
///               near.                         \\\
///=============================================\\\     


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentTrigger : MonoBehaviour
{
    [SerializeField] private Rigidbody ventDoor;
    [SerializeField] private DoorTrigger doorTrigger;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && doorTrigger.isClosed)
        {
            ventDoor.isKinematic = false;
            GetComponent<BoxCollider>().center += Vector3.down;
            GetComponent<AudioSource>().Play();
        }
    }
}
