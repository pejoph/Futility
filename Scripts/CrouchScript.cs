///=============================================\\\
///     Title   : CrouchScript.cs               \\\
///                                             \\\
///     Author  : Peter Phillips                \\\
///                                             \\\
///     Date    : First entry - 09.01.18        \\\
///               Last entry  - 11.01.18        \\\
///                                             \\\
///     Brief   : Allows the player to crouch   \\\
///               if player's headspace is      \\\
///               clear.                        \\\
///=============================================\\\


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrouchScript : MonoBehaviour
{
    private float standHeight = 2.0f;
    private float crouchHeight = .5f;
    private float targetHeight = 2.0f;
    private float standY = 0f;
    private float crouchY = .5f;
    private float targetY = 0f;
    private float crouchTransitionSpeed = 5f;
    private RaycastHit hit;    
	
	void Update ()
    {
		if ((Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl)) && 
            GetComponent<CharacterController>().isGrounded &&
            (targetHeight == standHeight || targetHeight == crouchHeight && !Physics.SphereCast(transform.position + Vector3.up * .2f, GetComponent<CharacterController>().radius, Vector3.up, out hit, 2f, ~(1 << LayerMask.NameToLayer("Player")))))
        {
            targetHeight = (targetHeight == standHeight) ? crouchHeight : standHeight;
            targetY = (targetY == standY) ? crouchY : standY;
        }

        if (GetComponent<CharacterController>().height != targetHeight)
        {
            if (targetHeight == standHeight && GetComponent<CharacterController>().height + .18f >= targetHeight)
            {
                GetComponent<CharacterController>().height = targetHeight;
            }
            
            GetComponent<CharacterController>().height = Mathf.Lerp(GetComponent<CharacterController>().height, targetHeight, Time.deltaTime * crouchTransitionSpeed);
        }

        if (GetComponent<CharacterController>().center.y != targetY)
        {
            if (targetY == standY && GetComponent<CharacterController>().center.y - .08f <= targetY)
            {
                GetComponent<CharacterController>().center = new Vector3(GetComponent<CharacterController>().center.x,
                                                                            targetY,
                                                                            GetComponent<CharacterController>().center.z);
            }

            GetComponent<CharacterController>().center = new Vector3(GetComponent<CharacterController>().center.x,
                                                                            Mathf.Lerp(GetComponent<CharacterController>().center.y, targetY, Time.deltaTime * crouchTransitionSpeed),
                                                                            GetComponent<CharacterController>().center.z);
        }


        if (targetHeight == crouchHeight)
        {
            GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_WalkSpeed = 1f;
            GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_RunSpeed = 1f;
            GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_JumpSpeed = 2f;
        }
        else
        {
            GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_WalkSpeed = 2f;
            GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_RunSpeed = 4f;
            GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_JumpSpeed = 5f;
        }
    }
}
