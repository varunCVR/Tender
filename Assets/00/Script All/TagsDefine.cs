using UnityEngine;

public class TagsDefine : MonoBehaviour
{
    public Transform Tag;
    public LayerMask layer;
 
    bool isTrue;

    private void Update()
    {
        if(isTrue)
        {
            if (this.GetComponent<Rigidbody>())
            {
                if (this.GetComponent<Rigidbody>().useGravity)
                {
                    Tag.gameObject.SetActive(true);
                }
                else
                {
                    Tag.gameObject.SetActive(false);
                }

                if(this.GetComponent<Rigidbody>().isKinematic)
                {
                    Tag.gameObject.SetActive(true);
                }
            }
            else
            {
                Tag.gameObject.SetActive(true);
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (((1 << collision.gameObject.layer) & layer) != 0)
        {
            isTrue = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        isTrue = false;
    }
}
