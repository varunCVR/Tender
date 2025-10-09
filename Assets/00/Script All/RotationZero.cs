using UnityEngine;

public class RotationZero : MonoBehaviour
{
    public Vector3 Rotation;

    public LayerMask layer;

    bool isGround;

    private void Update()
    {
        if(GetComponent<Rigidbody>())
        {
            if(GetComponent<Rigidbody>().useGravity)
            {
                if(isGround)
                {
                    transform.rotation = Quaternion.Euler(Rotation);                
                }              
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (((1 << collision.gameObject.layer) & layer) != 0)
        {
            isGround = true;
        }    
    }

    private void OnCollisionExit(Collision collision)
    {
        isGround = false;
    }
}
