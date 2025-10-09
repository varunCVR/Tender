using BNG;
using System.Collections;
using TMPro;
using UnityEngine;

public class fonaltreeConnection : MonoBehaviour
{
        public GameObject grabObj;
        public GameObject grabObj1;
        public GameObject grabObj2;
        [Space] 
        public doroScriptConnect doro1;
        public doroScriptConnect doro2;
        public doroScriptConnect doro3;
        [Space]
        public Transform leafPo1;
        public Transform leafPo2;
        public Transform leafPo3;
        [Space] 
        public bool w2Set;
        public bool w3Set;
        public bool w4Set;

        [Space] public bool timeEnding;

        [Header("wait Effect")]
        public GameObject lightObj;
        private bool oneCall;
        
        [Space]
        public Material dirtyMat;

        public Renderer rd1;
        public Renderer rd2;
        public Renderer rd3;
        private int i;

        IEnumerator allActivate()
        {
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
        
                timeEnding = true;
        
                w2Set = false;
                w3Set = false;
                w4Set = false;
                
                grabObj.GetComponent<Rigidbody>().mass = 3;
                grabObj.GetComponent<Grabbable>().enabled = true;
        
                grabObj1.GetComponent<Rigidbody>().mass = 3;
                grabObj1.GetComponent<Grabbable>().enabled = true;
        
                grabObj2.GetComponent<Rigidbody>().mass = 3;
                grabObj2.GetComponent<Grabbable>().enabled = true;

        }
        private void OnTriggerEnter(Collider oth)
        {
                if (oth.CompareTag("water2") && oth.GetComponent<Rigidbody>().mass==2 && doro1.rope)
                {
                        w2Set = true;
                }
                if (oth.CompareTag("water3") && oth.GetComponent<Rigidbody>().mass==2 && doro2.rope)
                {
                        w3Set = true;
                }
                if (oth.CompareTag("water4") && oth.GetComponent<Rigidbody>().mass==2 && doro3.rope)
                {
                        w4Set = true;
                }
        }

        private void Update()
        {
                if (!timeEnding)
                {
                        if (w2Set)
                        {
                                grabObj.transform.position = leafPo1.position;
                                grabObj.transform.rotation = leafPo1.rotation;
                        }

                        if (w3Set)
                        {
                                grabObj1.transform.position = leafPo2.position;
                                grabObj1.transform.rotation = leafPo2.rotation;
                        }

                        if (w4Set)
                        {
                                grabObj2.transform.position = leafPo3.position;
                                grabObj2.transform.rotation = leafPo3.rotation;
                        }
                        if (w2Set && w3Set && w4Set && i==0)
                        {
                                StartCoroutine(allActivate());
                                i = 1;
                        }
                }
        }
}
