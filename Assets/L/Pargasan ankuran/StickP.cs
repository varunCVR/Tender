using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickP : MonoBehaviour
{

    float secs;
    bool increase;
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            secs += Time.deltaTime;
            if(secs > 2 && !increase)
            {
                other.GetComponent<BeakerWater>().counter += 1;
                increase = true;
            }
            
        }
    }
}
