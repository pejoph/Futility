///=============================================\\\
///     Title   : CameraStart.cs                \\\
///                                             \\\
///     Author  : Peter Phillips                \\\
///                                             \\\
///     Date    : First entry - 13.01.18        \\\
///               Last entry  - 13.01.18        \\\
///                                             \\\
///     Brief   : Fades out the menu blur       \\\
///               when the game starts.         \\\
///=============================================\\\     


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class CameraStart : MonoBehaviour
{
    [SerializeField] private MenuScript menu;
    [SerializeField] private PostProcessingProfile postProcessing;

    private bool hasClosedMenu = false;
    	
	void Update ()
    {
		if (menu.hasStartedGame && !hasClosedMenu)
        {
            hasClosedMenu = true;
            StartCoroutine("Focus");
            Debug.Log("yeet");
        }
	}

    IEnumerator Focus()
    {
        DepthOfFieldModel.Settings settings = postProcessing.depthOfField.settings;
        Debug.Log("started");

        for (float f = 0.1f; f <= 5.0f; f += 2 * Time.deltaTime)
        {
            settings.focusDistance = f;
            postProcessing.depthOfField.settings = settings;
            yield return null;
        }

        postProcessing.depthOfField.enabled = false;
    }
}
