using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterkhillicolorch : MonoBehaviour
{
    [SerializeField] private Animator myAnimationController;

    private void OnTriggerEnter(Collider other)

    {
        if (other.CompareTag("Player"))
        {

            myAnimationController.SetBool("watercol", true);

        }
    }

    private void OnTriggerExit(Collider other)

    {
        if (other.CompareTag("Player"))
        {

            myAnimationController.SetBool("watercol", false);

        }
    }
}
