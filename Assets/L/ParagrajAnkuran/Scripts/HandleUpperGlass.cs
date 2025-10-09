
using System.Collections;
using Oculus.Interaction;
using UnityEngine;

public class HandleUpperGlass : MonoBehaviour
{
    public GameObject glassObject; 
    public GlassHandler handler;
    public GameObject targetPos;

    bool follow, glassPuted;

    public GameObject object1, object2;
    public float maxX;
    public float maxY;
    public float maxZ;

    public AudioSource audioSource;
    public AudioClip eighth;

    public Rigidbody rb;
    public Grabbable grabbable;
    public BoxCollider colls;
    public MeshRenderer renderer;

    private void Update()
    {
        if (follow)
        {

            glassObject.SetActive(true);
            handler.glassAttached = true;
             follow = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CopperS"))
        {
              
            follow = true;
            glassPuted = true;

            grabbable.enabled = false;
            renderer.enabled = false;
            colls.enabled = false;
            Destroy(rb);

            StartCoroutine(IncreaseWaterDropSizeX(maxX));
            StartCoroutine(IncreaseWaterDropSizeZ(maxZ));
            StartCoroutine(IncreaseWaterDropSizeY(maxY));

            StartCoroutine(PlayEighthAudio());
        }
    }
    IEnumerator PlayEighthAudio()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(eighth);
        yield return new WaitForSeconds(5f);
    }
    IEnumerator IncreaseWaterDropSizeX(float maxX)
    {

        while (object1.transform.localScale.x < maxX)
        {
            float i = object1.transform.localScale.x;

            i += 0.0001f;
            object1.transform.localScale = new Vector3(i, object1.transform.localScale.y, object1.transform.localScale.z);
            object2.transform.localScale = new Vector3(i, object2.transform.localScale.y, object2.transform.localScale.z);
            yield return new WaitForFixedUpdate();
        }
    }
    IEnumerator IncreaseWaterDropSizeZ(float maxZ)
    {
        while (object1.transform.localScale.z < maxZ)
        {
            float i = object1.transform.localScale.z;
            i += 0.0001f;
            object1.transform.localScale = new Vector3(object1.transform.localScale.x, object1.transform.localScale.y, i);
            object2.transform.localScale = new Vector3(object2.transform.localScale.x, object2.transform.localScale.y, i);
            yield return new WaitForFixedUpdate();
        }
    }
    IEnumerator IncreaseWaterDropSizeY(float maxY)
    {
        while (object1.transform.localScale.y < maxY)
        {
            float i = object1.transform.localScale.y;
            i += 0.0001f;
            object1.transform.localScale = new Vector3(object1.transform.localScale.x, i, object1.transform.localScale.z);
            object2.transform.localScale = new Vector3(object2.transform.localScale.x, i, object2.transform.localScale.z);
            yield return new WaitForFixedUpdate();
        }
    }
}
