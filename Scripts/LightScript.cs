///=============================================\\\
///     Title   : LightScript.cs                \\\
///                                             \\\
///     Author  : Peter Phillips                \\\
///                                             \\\
///     Date    : First entry - 12.01.18        \\\
///               Last entry  - 13.01.18        \\\
///                                             \\\
///     Brief   : Controls when the lights      \\\
///               turn on and how they flicker. \\\
///=============================================\\\     


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    [SerializeField] private DoorTrigger doorScript;
    [SerializeField] private GameObject lamp1;
    [SerializeField] private GameObject lamp2;
    [SerializeField] private Light light1;
    [SerializeField] private Light light2;
    [SerializeField] private Light torch;

    private float timer = 0f;
    private float flickerTimer1 = 0f;
    private float flickerTimer2 = 0f;
    private float rand1;
    private float rand2;
    private bool hasSwitchedOn = false;
	
	void Update ()
    {
        torch.intensity = Mathf.Lerp(torch.intensity, Random.Range(2f, 3f), Time.deltaTime * 10);

		if (doorScript.isClosed)
        {
            timer += Time.deltaTime;

            if (timer >= 2.5f && !hasSwitchedOn)
            {
                GetComponent<AudioSource>().Play();
                hasSwitchedOn = true;
            }

            if (timer >= 3f)
            {
                lamp1.GetComponent<MeshRenderer>().enabled = true;
                lamp2.GetComponent<MeshRenderer>().enabled = true;
                light1.enabled = true;
                light2.enabled = true;

                rand1 = Random.Range(.6f, .8f);
                rand2 = Random.Range(.3f, .5f);

                if (rand1 <= .606)
                {
                    rand1 = .6f;
                }
                else
                {
                    rand1 = .8f;
                }

                if (rand2 >= .494f || flickerTimer2 > 0f)
                {
                    rand2 = .8f;

                    if (flickerTimer2 <= 0f)
                    {
                        flickerTimer2 = Random.Range(.2f, .6f);
                    }
                    else
                    {
                        flickerTimer2 -= Time.deltaTime;
                    }                    
                }

                light1.intensity = rand1;
                light2.intensity = rand2;
            }
        }
	}
}
