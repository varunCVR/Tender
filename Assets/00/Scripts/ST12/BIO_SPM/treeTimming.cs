using BNG;
using TMPro;
using UnityEngine;
using System.Collections;

public class treeTimming : MonoBehaviour
{
    public GameObject grabObj;
   
    public GameObject grabObj1;
   
    public GameObject grabObj2;
    [Space] 
    
    public bool timeOver;
    public GameObject lightObj;

    [Space] private int i;

    public leftSetPosForAll leaf1;
    public leftSetPosForAll leaf2;
    public leftSetPosForAll leaf3;
    [Space]
    public Material dirtyMat;

    public Renderer rd1;
    public Renderer rd2;
    public Renderer rd3;


    [Space] public ParticleSystem plDust;
    IEnumerator leafTime()
    {
        plDust.Play();
        yield return new WaitForSecondsRealtime(1);
        lightObj.SetActive(true);
        lightObj.GetComponent<TextMeshProUGUI>().text = "15";
        yield return new WaitForSecondsRealtime(1);
        lightObj.GetComponent<TextMeshProUGUI>().text = "14";
        yield return new WaitForSecondsRealtime(1);
        lightObj.GetComponent<TextMeshProUGUI>().text = "13";
        yield return new WaitForSecondsRealtime(1);
        lightObj.GetComponent<TextMeshProUGUI>().text = "12";
        yield return new WaitForSecondsRealtime(1);
        lightObj.GetComponent<TextMeshProUGUI>().text = "11";
        yield return new WaitForSecondsRealtime(1);
        lightObj.GetComponent<TextMeshProUGUI>().text = "10";
        yield return new WaitForSecondsRealtime(1);
        lightObj.GetComponent<TextMeshProUGUI>().text = "9";
        yield return new WaitForSecondsRealtime(1);
        lightObj.GetComponent<TextMeshProUGUI>().text = "8";
        yield return new WaitForSecondsRealtime(1);
        lightObj.GetComponent<TextMeshProUGUI>().text = "7";
        yield return new WaitForSecondsRealtime(1);
        lightObj.GetComponent<TextMeshProUGUI>().text = "6";
        yield return new WaitForSecondsRealtime(1);
        lightObj.GetComponent<TextMeshProUGUI>().text = "5";
        yield return new WaitForSecondsRealtime(1);
        lightObj.GetComponent<TextMeshProUGUI>().text = "4";
        yield return new WaitForSecondsRealtime(1);
        lightObj.GetComponent<TextMeshProUGUI>().text = "3";
        yield return new WaitForSecondsRealtime(1);
        lightObj.GetComponent<TextMeshProUGUI>().text = "2";
        yield return new WaitForSecondsRealtime(1);
        lightObj.GetComponent<TextMeshProUGUI>().text = "1";
        yield return new WaitForSecondsRealtime(1);
        lightObj.SetActive(false);

        rd1.material = dirtyMat;
        rd2.material = dirtyMat;
        rd3.material = dirtyMat;
        
        timeOver = true;
        
        leaf1.EnterTime = false;
        leaf2.EnterTime = false;
        leaf3.EnterTime = false;
        
        grabObj.GetComponent<Rigidbody>().mass = 3;
        grabObj.GetComponent<Grabbable>().enabled = true;
        
        grabObj1.GetComponent<Rigidbody>().mass = 3;
        grabObj1.GetComponent<Grabbable>().enabled = true;
        
        grabObj2.GetComponent<Rigidbody>().mass = 3;
        grabObj2.GetComponent<Grabbable>().enabled = true;
        plDust.Stop();

    }
    
    private void Update()
    {
        if (leaf1.EnterTime && leaf2.EnterTime && leaf3.EnterTime && i==0)
        {
            StartCoroutine(leafTime());
            i = 1;
        }
    }
}
