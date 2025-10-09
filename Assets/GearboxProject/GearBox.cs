using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Slider = UnityEngine.UI.Slider;

public class GearBox : MonoBehaviour
{
    public Slider slider;
    public Text speedTextOne, speedTextTwo, btnText;
    public TextMeshProUGUI sliderText;
    public Material chromeMat, redMat, secChromeMat;
    public MeshRenderer emptySpareRenderer;
    public MeshRenderer childeMeshRenderer;

    public List<Transform> greenPos;
    public List<GameObject> originalPos;
    public List<MeshRenderer> renders;
    public List<Rigidbody> rbs;
    public List<BoxCollider> colliders;
    public List<HelperScrew> helperScrew;

    public GameObject motor, stand;

    public GameObject transparentButtonCanvas;
    private Collider obj;
    
    private bool one = false,
        two = false,
        three = false,
        four = false,
        five = false,
        six = false,
        seven = false,
        eight = false,
        nine = false,
        ten = false,
        eleven = false,
        twelv = false;

    private bool isStartToRotate = false;
    private bool showUI;
    private bool setOnlyOnce, setOnlyOnceSec;
    public int code = 1;
    private int lastCode;


    public bool rotate;
    public float Timer;
    public Text timerText;
    private void Start()
    {
        transparentButtonCanvas.SetActive(false);
        showUI = false;
        for (int i = 0; i < greenPos.Count; i++)
        {
            renders.Add(greenPos[i].GetComponent<MeshRenderer>());
            renders[i].enabled = false;
            rbs.Add(originalPos[i].GetComponent<Rigidbody>());
            helperScrew.Add(originalPos[i].GetComponent<HelperScrew>());
            colliders.Add(originalPos[i].GetComponent<BoxCollider>());
        }

        childeMeshRenderer.enabled = false;

        if (code == 1)
        {
            renders[0].enabled = true;
        }

        setOnlyOnce = false;
        setOnlyOnceSec = false;
        lastCode = code;
    }

    private void FixedUpdate()
    {

       
        /*if (rotate)
        {
            Timer += Time.deltaTime;
            if (Timer > 60)
            {
                Timer = 0;
               
            }
            timerText.text = Timer.ToString("0");
            float val = slider.value;
            speedTextOne.text = (1 * (int) val).ToString(CultureInfo.CurrentCulture) + " RPM";
            speedTextTwo.text = (4 * (int) val).ToString(CultureInfo.CurrentCulture)+ " RPM";
            originalPos[0].transform.Rotate(-Vector3.right * (val*2.5f)/30);
            originalPos[1].transform.Rotate(Vector3.right * (val*10f)/30);
        }*/
        MovementMethods();
        sliderText.text = slider.value.ToString("0") + " RPM";
        if (showUI && isStartToRotate)
        {
            Timer += Time.deltaTime;
            if (Timer > 60)
            {
                Timer = 0;
               
            }
            timerText.text = Timer.ToString("0");
            float val = slider.value;
            speedTextOne.text = (1 * (int) val).ToString(CultureInfo.CurrentCulture);
            speedTextTwo.text = (4 * (int) val).ToString(CultureInfo.CurrentCulture);
            originalPos[0].transform.Rotate(-Vector3.right * (val*2.5f)/30);
            originalPos[1].transform.Rotate(Vector3.right * (val*10f)/30);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        FindOutObjects(other);
    }

    private void OnTriggerExit(Collider other)
    {
        other.GetComponent<MeshRenderer>().material = chromeMat;
    }
 void MovementMethods()
    {
        if (one)
        {
            MoveObjectsWithRot(originalPos[0].transform, greenPos[0], renders[0], renders[1], rbs[0], colliders[0],
                true);
        }

        if (two)
        {
            MoveObjectsWithRot(originalPos[1].transform, greenPos[1], renders[1], renders[2], rbs[1], colliders[1],
                false);
            setOnlyOnceSec = true;
        }

        if (three)
        {
            MoveObjects(originalPos[2].transform, greenPos[2], renders[2], renders[3], rbs[2], colliders[2], false);
        }

        if (four)
        {
            MoveObjects(originalPos[3].transform, greenPos[3], renders[3], renders[4], rbs[3], colliders[3], false);
        }

        if (five)
        {
            MoveObjects(originalPos[4].transform, greenPos[4], renders[4], renders[5], rbs[4], colliders[4], false);
        }

        if (six)
        {
            MoveObjects(originalPos[5].transform, greenPos[5], renders[5], renders[6], rbs[5], colliders[5], false);
        }

        if (seven)
        {
            MoveObjects(originalPos[6].transform, greenPos[6], renders[6], renders[7], rbs[6], colliders[6], false);
        }

        if (eight)
        {
            MoveObjects(originalPos[7].transform, greenPos[7], renders[7], renders[8], rbs[7], colliders[7], false);
        }

        if (nine)
        {
            MoveObjects(originalPos[8].transform, greenPos[8], renders[8], renders[9], rbs[8], colliders[8], false);
        }

        if (ten)
        {
            MoveObjects(originalPos[9].transform, greenPos[9], renders[9], renders[10], rbs[9], colliders[9], false,
                true);
        }
        else
        {
            rbs[9].isKinematic = false;
            colliders[9].isTrigger = false;
        }

        if (eleven)
        {
            MoveObjects(originalPos[10].transform, greenPos[10], renders[10], renders[11], rbs[10], colliders[10],
                false, true);
        }
        else
        {
            rbs[10].isKinematic = false;
            colliders[10].isTrigger = false;
        }

        if (twelv)
        {
            MoveObjects(originalPos[11].transform, greenPos[11], renders[11], emptySpareRenderer, rbs[11],
                colliders[11],
                false, true);
        }
        else
        {
            rbs[11].isKinematic = false;
            colliders[11].isTrigger = false;
        }
    }
    void FindOutObjects(Collider other)
    {
        if (other.CompareTag("partOne") && code == 1)
        {
            helperScrew[0].isConnected = true;
            one = true;
            code = 2;
        }
        else if (other.CompareTag("partTwo") && code == 2 && helperScrew[0].isConnected)
        {
            helperScrew[1].isConnected = true;
            two = true;
            code = 3;
        }
        else if (other.CompareTag("partThree") && code == 3 && helperScrew[1].isConnected)
        {
            helperScrew[2].isConnected = true;
            three = true;
            code = 4;
        }
        else if (other.CompareTag("partFour") && code == 4 && helperScrew[2].isConnected)
        {
            helperScrew[3].isConnected = true;
            four = true;
            code = 5;
        }
        else if (other.CompareTag("partFive") && code == 5 && helperScrew[3].isConnected)
        {
            helperScrew[4].isConnected = true;
            five = true;
            code = 6;
        }
        else if (other.CompareTag("partSix") && code == 6 && helperScrew[4].isConnected)
        {
            helperScrew[5].isConnected = true;
            six = true;
            code = 7;
        }
        else if (other.CompareTag("partSeven") && code == 7 && helperScrew[5].isConnected)
        {
            helperScrew[6].isConnected = true;
            seven = true;
            code = 8;
        }
        else if (other.CompareTag("partEight") && code == 8 && helperScrew[6].isConnected)
        {
            helperScrew[7].isConnected = true;
            eight = true;
            code = 9;
        }
        else if (other.CompareTag("partNine") && code == 9 && helperScrew[7].isConnected)
        {
            helperScrew[8].isConnected = true;
            nine = true;
            code = 10;
            isStartToRotate = true;
        }
        else if (other.CompareTag("partTen") && code == 10 && helperScrew[8].isConnected)
        {
            helperScrew[9].isConnected = true;
            ten = true;
            code = 11;
        }
        else if (other.CompareTag("partEleven") && code == 11 && helperScrew[9].isConnected)
        {
            helperScrew[10].isConnected = true;
            eleven = true;
            code = 12;
        }
        else if (other.CompareTag("partTwelv") && code == 12 && helperScrew[10].isConnected)
        {
            helperScrew[11].isConnected = true;
            twelv = true;
            code = 13;

            motor.SetActive(true);
            stand.SetActive((true));
            transparentButtonCanvas.SetActive(true);
            //obj = other;
            StartCoroutine(ChangeMat(other));
        }
        else
        {
            if (!other.GetComponent<HelperScrew>().isConnected)
                other.GetComponent<MeshRenderer>().material = redMat;
        }
    }

   

    void MoveObjects(Transform originalPos, Transform targetPos, MeshRenderer oldRenderer, MeshRenderer newRenderer,
        Rigidbody rb, BoxCollider meshCollider, bool i)
    {
        //originalPos.position = Vector3.MoveTowards(originalPos.position, targetPos.position, Time.deltaTime);
        Destroy(rb);
        Destroy(meshCollider);
        originalPos.position = targetPos.position;
        originalPos.eulerAngles = targetPos.eulerAngles;

        oldRenderer.enabled = false;
        newRenderer.enabled = true;
    }

    void MoveObjects(Transform originalPos, Transform targetPos, MeshRenderer oldRenderer, MeshRenderer newRenderer,
        Rigidbody rb, BoxCollider meshCollider, bool i, bool isDifferent)
    {
        if (isDifferent)
        {
            if (Vector3.Distance(originalPos.position, targetPos.position) < 0.2f)
            {
                rb.isKinematic = true;
                // Destroy(meshCollider);
                meshCollider.isTrigger = true;
                originalPos.position = Vector3.MoveTowards(originalPos.position, targetPos.position, Time.deltaTime);
                originalPos.eulerAngles = targetPos.eulerAngles;
                oldRenderer.enabled = false;
                newRenderer.enabled = true;
            }
            else
            {
                rb.isKinematic = false;
                meshCollider.isTrigger = false;
            }
        }
    }

    void MoveObjectsWithRot(Transform originalPos, Transform targetPos, MeshRenderer oldRenderer,
        MeshRenderer newRenderer,
        Rigidbody rb, BoxCollider meshCollider, bool i)
    {
        //originalPos.position = Vector3.MoveTowards(originalPos.position, targetPos.position, Time.deltaTime);
        Destroy(rb);
        Destroy(meshCollider);
        originalPos.position = targetPos.position;
        if (!setOnlyOnce)
        {
            originalPos.eulerAngles = targetPos.eulerAngles;
            setOnlyOnce = true;
        }

        if (!setOnlyOnceSec)
        {
            originalPos.eulerAngles = targetPos.eulerAngles;
        }

        oldRenderer.enabled = false;
        newRenderer.enabled = true;
        if (i)
        {
            childeMeshRenderer.enabled = true;
        }
        else
        {
            childeMeshRenderer.enabled = false;
        }
    }

    public void ShowUI()
    {
        if (!isStartToRotate)
        {
            StartCoroutine(SetButtonText());
        }
        else
        {
            showUI = true;
        }
    }

    IEnumerator SetButtonText()
    {
        StopCoroutine(SetButtonText());
        btnText.text = "Please Attach All Parts First....";
        yield return new WaitForSeconds(3f);
        btnText.text = "Start";
    }

   // public void SetObjTransparent()
   // {
        //originalPos[9].GetComponent<MeshRenderer>().material = secChromeMat;
       // obj.gameObject.GetComponent<MeshRenderer>().material = secChromeMat;
       // originalPos[10].GetComponent<MeshRenderer>().material = secChromeMat;
   // }
    IEnumerator ChangeMat(Collider other)
    {
        yield return new WaitForSeconds(1f);
        originalPos[9].GetComponent<MeshRenderer>().material = secChromeMat;
        other.gameObject.GetComponent<MeshRenderer>().material = secChromeMat;
        originalPos[10].GetComponent<MeshRenderer>().material = secChromeMat;
    }
}