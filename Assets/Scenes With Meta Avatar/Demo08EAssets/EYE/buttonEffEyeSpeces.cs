using UnityEngine;

public class buttonEffEyeSpeces : MonoBehaviour
{
    public Material buttonEff_RED;
    public Material buttonEff_GREEN;

    [Space]
    public bool Confirm;
    public buttonEffEyeSpeces offenceConf;
    [Space]
    public bool guruB;
    public bool laguB;

    [Space]
    public Transform upLoc;
    public Transform downLoc;
    public Transform targetTrans;

    [Space]
    public GameObject laguScpt;
    public GameObject guruScpt;

    [Space]
    public float clickSpeed;
    public Renderer changer;


    public void ButtonOnClick()
    {
        Confirm =! Confirm;
        offenceConf.Confirm =!Confirm;
        GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
        if (guruB)
        {
            guruScpt.SetActive(Confirm);
            laguScpt.SetActive(!Confirm);
        }

        if (laguB)
        {
            laguScpt.SetActive(Confirm);
            guruScpt.SetActive(!Confirm);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
            Confirm =! Confirm;
            offenceConf.Confirm =!Confirm;
            GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
        if (guruB)
        {
            guruScpt.SetActive(Confirm);
            laguScpt.SetActive(!Confirm);
        }

        if (laguB)
        {
            laguScpt.SetActive(Confirm);
            guruScpt.SetActive(!Confirm);
        }
    }

    public void ModifiedButtonClick()
    {
        Confirm =! Confirm;
        offenceConf.Confirm =!Confirm;
        GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
        if (guruB)
        {
            guruScpt.SetActive(Confirm);
            laguScpt.SetActive(!Confirm);
        }

        if (laguB)
        {
            laguScpt.SetActive(Confirm);
            guruScpt.SetActive(!Confirm);
        }
    }

    public void Update()
    {
        if (Confirm && targetTrans.position != downLoc.position)
        {
            targetTrans.position = Vector3.MoveTowards(targetTrans.position, downLoc.position, Time.deltaTime * clickSpeed);
        }
        if (!Confirm && targetTrans.position != upLoc.position)
        {
            targetTrans.position = Vector3.MoveTowards(targetTrans.position, upLoc.position, Time.deltaTime * clickSpeed);
        }

        colorChanger();
      

    }

    void colorChanger()
    {
        if (targetTrans.position == downLoc.position)
        {
            changer.material = buttonEff_GREEN;
        }
        if(targetTrans.position == upLoc.position)
        {
            changer.material = buttonEff_RED;
        }
    }

}
