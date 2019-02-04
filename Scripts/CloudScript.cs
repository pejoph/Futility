///=============================================\\\
///     Title   : CloudScript.cs                \\\
///                                             \\\
///     Author  : Peter Phillips                \\\
///                                             \\\
///     Date    : First entry - 13.01.18        \\\
///               Last entry  - 13.01.18        \\\
///                                             \\\
///     Brief   : Rotates the clouds in the     \\\
///               sky box.                      \\\
///=============================================\\\     


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : MonoBehaviour
{
	void Update ()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time);
	}
}
