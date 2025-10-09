using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icedesolve : MonoBehaviour
{
    [SerializeField] private Animator myAnimationController;

    private void OnTriggerEnter(Collider other)

    {
        if (other.CompareTag("iceall"))
        {

            myAnimationController.SetBool("ice", true);

        }
    }

    private void OnTriggerExit(Collider other)

    {
        if (other.CompareTag("iceall"))
        {

            myAnimationController.SetBool("ice", false);

        }
    }
}
