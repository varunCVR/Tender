using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPHNature : MonoBehaviour
{
    public GameObject Warning;
    public GameObject[] values;
    private void Start()
    {
        foreach(GameObject obj in values)
        {
            obj.SetActive(false);
        }
    }

    public void click()
    {
        Warning.SetActive(true);
        StartCoroutine(Wait());
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2.5f);
        Warning.SetActive(false);
    }
}
