///=============================================\\\
///     Title   : DoorTrigger.cs                \\\
///                                             \\\
///     Author  : Peter Phillips                \\\
///                                             \\\
///     Date    : First entry - 10.01.18        \\\
///               Last entry  - 13.01.18        \\\
///                                             \\\
///     Brief   : Closes the door when player   \\\
///               approaches.                   \\\
///=============================================\\\


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public bool isClosed = false;
    
    [SerializeField] private Rigidbody door;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !isClosed)
        {
            door.useGravity = true;
            isClosed = true;
            GetComponent<BoxCollider>().center += Vector3.down;
            GetComponent<AudioSource>().Play();
        }
    }
}
