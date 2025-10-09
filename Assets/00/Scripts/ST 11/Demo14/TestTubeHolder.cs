using UnityEngine;
    public class TestTubeHolder : MonoBehaviour
    {
        public GameObject kasnali1;

        public GameObject KasnaliPos;
        public GameObject h1, h2;

        GameObject Kasnali;

        [HideInInspector]
        public bool isPos, isCheck;

    private void Update()
    {
        if (kasnali1.GetComponent<CapsuleCollider>().enabled)
        {
            this.GetComponent<Collider>().enabled = true;
        }

        if (isCheck)
        {
            h1.transform.localEulerAngles = new Vector3(0, 3, 0);
            h2.transform.localEulerAngles = new Vector3(0, -3, 0);
            Kasnali.transform.parent = KasnaliPos.transform;
            Kasnali.transform.position = KasnaliPos.transform.position;
            Kasnali.transform.rotation = KasnaliPos.transform.rotation;
        }
        else
        {
            if(Kasnali)
            {
                h1.transform.localEulerAngles = new Vector3(0, -10, 0);
                h2.transform.localEulerAngles = new Vector3(0, 10, 0);
                Kasnali.transform.parent = null;
                Kasnali.transform.position = Kasnali.transform.position;
                Kasnali.transform.rotation = Kasnali.transform.rotation;
            }      
        }      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "patti")
        {
            Kasnali = other.gameObject;
            isCheck = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "patti")
        {
            isCheck = false;
        }
    }
}
