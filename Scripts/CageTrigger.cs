///=============================================\\\
///     Title   : CageTrigger.cs                \\\
///                                             \\\
///     Author  : Peter Phillips                \\\
///                                             \\\
///     Date    : First entry - 13.01.18        \\\
///               Last entry  - 13.01.18        \\\
///                                             \\\
///     Brief   : Plays an audioclip when       \\\
///               the player reaches the end.   \\\
///=============================================\\\     


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageTrigger : MonoBehaviour
{
    private bool hasTriggered = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered)
        {
            GetComponent<AudioSource>().Play();
            hasTriggered = true;
        }
    }
}
