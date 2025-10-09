using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FORSPIN : MonoBehaviour
{
    public Transform roter;
    public Transform reacher;
    public fixDir SetDir;
    public float rotateSpeed;
    public float reacherRange;
    public ParticleSystem reacherFollower;

    [Header("PlusMin-Sign")] 
    public GameObject rightP;
    public GameObject rightN;
    public GameObject leftP;
    public GameObject lefNN;

    [HideInInspector]
    public int helper;
    public enum fixDir
    {
        up,down,forword,back,right,left
    }
    void Update()
    {
        if (reacher.transform.localPosition.x < reacherRange)
        {
            if (helper == 0)
            {
                reacherFollower.Play();
                helper = 1;
            }
            reacher.transform.localPosition = new Vector3(reacher.transform.localPosition.x + Time.deltaTime /2.2f,
                reacher.transform.localPosition.y, reacher.transform.localPosition.z);
        }
        /*if (reacher.transform.localPosition.x >=reacherRange)
        {
            helper = 0;
            reacherFollower.Stop();
            reacher.transform.localPosition = new Vector3(0,
                reacher.transform.localPosition.y, reacher.transform.localPosition.z);
        }*/
        if (SetDir == fixDir.up)
        {
            roter.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
        }
        if (SetDir == fixDir.down)
        {
            roter.Rotate(Vector3.down * Time.deltaTime * rotateSpeed);
        }
        if (SetDir == fixDir.forword)
        {
            roter.Rotate(Vector3.forward * Time.deltaTime * rotateSpeed);
        }
        if (SetDir == fixDir.back)
        {
            roter.Rotate(Vector3.back * Time.deltaTime * rotateSpeed);
        }
        if (SetDir == fixDir.right)
        {
            roter.Rotate(Vector3.right * Time.deltaTime * rotateSpeed);
        }
        if (SetDir == fixDir.left)
        {
            roter.Rotate(Vector3.left * Time.deltaTime * rotateSpeed);
        }
        plusMinusChanges();
    }
    public void plusMinusChanges()
    {
        if (reacher.transform.position.x < 0.044f && !lefNN.activeInHierarchy)
        {
            rightP.SetActive(true);
            rightN.SetActive(false);
            leftP.SetActive(false);
            lefNN.SetActive(true);
        }
        else if (reacher.transform.position.x > 0.044f && lefNN.activeInHierarchy)
        {
            rightP.SetActive(false);
            rightN.SetActive(true);
            leftP.SetActive(!rightP.activeInHierarchy);
            lefNN.SetActive(!rightN.activeInHierarchy);
        }
    }
}
