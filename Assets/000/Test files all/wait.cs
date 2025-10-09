using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wait : MonoBehaviour
{
    public GameObject abc = null;

    public void Start()
    {
        abc.SetActive(false);

        //showobj();

        StartCoroutine(WaitBeforeShow());
    }
private void showobj()

    {
        abc.SetActive(true);
    }
private IEnumerator WaitBeforeShow()

    {
        yield return new WaitForSeconds(5);

        abc.SetActive(true);
    }
}
