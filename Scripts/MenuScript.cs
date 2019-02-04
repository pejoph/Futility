///=============================================\\\
///     Title   : MenuScript.cs                 \\\
///                                             \\\
///     Author  : Peter Phillips                \\\
///                                             \\\
///     Date    : First entry - 13.01.18        \\\
///               Last entry  - 13.01.18        \\\
///                                             \\\
///     Brief   : Controls the start menu.      \\\
///=============================================\\\     


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.PostProcessing;

public class MenuScript : MonoBehaviour
{
    public bool hasStartedGame = false;
    [SerializeField] private PostProcessingProfile postProcessing;

    void Start()
    {
        DepthOfFieldModel.Settings settings = postProcessing.depthOfField.settings;
        settings.focusDistance = .1f;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        postProcessing.depthOfField.enabled = true;
        postProcessing.depthOfField.settings = settings;
    }

    public void Begin()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        hasStartedGame = true;
        Destroy(this.gameObject);
    }
}
