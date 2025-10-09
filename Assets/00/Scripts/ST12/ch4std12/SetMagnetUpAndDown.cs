using Oculus.Interaction;
using UnityEngine;

public class SetMagnetUpAndDown : MonoBehaviour
{
    public bool Connected;
    private GameObject colObj;
    public GameObject[] nextTrigger;

    public bool last;
    [Header("meshRemover")] public GameObject[] meshAll; 
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == name)
        {
            GetComponent<Collider>().enabled = false;
            other.GetComponent<Collider>().enabled = false;
            other.GetComponent<Grabbable>().enabled = false;
            Destroy(other.GetComponent<Rigidbody>());
            colObj = other.gameObject;
            if (!last) {
                foreach (GameObject nextTg in nextTrigger) {
                    nextTg.SetActive(true);
                }
            }
            foreach (GameObject mes in meshAll) {
                Destroy(mes);
            }
            Connected = true;
        }
    }
    private void Update() {
        if (Connected) {
            if (colObj.transform.position != transform.position) {
                colObj.transform.position =
                    Vector3.MoveTowards(colObj.transform.position, transform.position, Time.deltaTime);
            }

            if (colObj.transform.rotation != transform.rotation) {        
                colObj.transform.rotation = Quaternion.Lerp(colObj.transform.rotation, transform.rotation, Time.deltaTime * 10);
            }
        }
    }
}
