using UnityEngine;

public class MetalsDetails : MonoBehaviour
{
    public GameObject DText;

    public TMPro.TMP_Dropdown[] DD;

    public int[] Ans;

    private void Update()
    {
        if (DD[0].value == Ans[0] && DD[1].value == Ans[1] && DD[2].value == Ans[2] && DD[3].value == Ans[3])
        {
            DText.SetActive(true);
        }
        else
        {
            DText.SetActive(false);
        }
    }
}
