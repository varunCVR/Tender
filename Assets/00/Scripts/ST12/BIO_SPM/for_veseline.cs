    using System;
    using UnityEngine;

    public class for_veseline : MonoBehaviour
    {
        public GameObject VESOLINEaLL;
        [HideInInspector] public bool vasolated;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("S") && !vasolated)
            {
                VESOLINEaLL.SetActive(true);
                vasolated = true;
            }
        }
    }
