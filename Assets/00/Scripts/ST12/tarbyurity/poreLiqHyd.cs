using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poreLiqHyd : MonoBehaviour
{
    public Transform hydWater;
    public Renderer hydPoreLiq;
    public float poreSpeed;
    public float lossSpeed;
    public bool hydPored;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("water2") && other.GetComponent<Rigidbody>().mass==1)
        {
            if (hydPoreLiq.material.GetFloat("_Fill") < 0.55f) {
                float fillPoint = hydPoreLiq.material.GetFloat("_Fill") + Time.deltaTime * poreSpeed;
                hydPoreLiq.material.SetFloat("_Fill",fillPoint);
                hydWater.transform.localScale = new Vector3(hydWater.transform.localScale.x,
                    hydWater.transform.localScale.y - Time.deltaTime *lossSpeed, hydWater.transform.localScale.z);
            }
            else if (hydPoreLiq.material.GetFloat("_Fill")>=0.55f && !hydPored) {
                hydPored = true;
            }
        }       
    }
}
