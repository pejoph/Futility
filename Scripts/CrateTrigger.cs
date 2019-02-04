///=============================================\\\
///     Title   : CrateTrigger.cs               \\\
///                                             \\\
///     Author  : Peter Phillips                \\\
///                                             \\\
///     Date    : First entry - 10.01.18        \\\
///               Last entry  - 11.01.18        \\\
///                                             \\\
///     Brief   : Replaces the crates with      \\\
///               broken models when the player \\\
///               steps on them.                \\\
///=============================================\\\


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateTrigger : MonoBehaviour
{
    [SerializeField] private GameObject brokenCrate;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(this.gameObject);
            GameObject crate = Instantiate(brokenCrate, transform.position, Quaternion.identity);
            crate.transform.localScale = transform.localScale;
            crate.transform.localRotation = transform.localRotation;
        }
    }
}
