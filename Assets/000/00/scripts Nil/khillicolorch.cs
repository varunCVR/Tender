using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class khillicolorch : MonoBehaviour
{
    [SerializeField] private Animator myAnimationController;

    private void OnTriggerEnter(Collider other)

    {
        if (other.CompareTag("Player"))
        {

            myAnimationController.SetBool("khillico", true);

        }
    }

    private void OnTriggerExit(Collider other)

    {
        if (other.CompareTag("Player"))
        {

            myAnimationController.SetBool("khillico", false);

        }
    }
}
