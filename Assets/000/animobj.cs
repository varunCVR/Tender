using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pattianimation : MonoBehaviour
{
    [SerializeField] private Animator myAnimationController;

    private void OnTriggerEnter(Collider other)

    {
        if (other.CompareTag("patti"))
        {

            myAnimationController.SetBool("pattianim1", true);

        }
    }
}
