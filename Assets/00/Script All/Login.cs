using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

public class Login : MonoBehaviour
{
    
    public TMP_InputField name;
    public TMP_Dropdown std;
    public TMP_InputField div;
    public TMP_InputField rollno;
    public TextMeshPro err1; //Please fill out all deatils
    public TextMeshPro err2; //User does not exists
    public TextMeshPro err3; //Something went wrong

    public void CallLink()
    {
        
        string studentName = name.text;
        string studentStd = std.options[std.value].text;
        string studentDiv = div.text;
        string studentRollno = rollno.text;
        if (string.IsNullOrEmpty(studentName) || string.IsNullOrEmpty(studentStd) || string.IsNullOrEmpty(studentDiv) ||
            string.IsNullOrEmpty(studentRollno))
        {
            err1.gameObject.SetActive(true);
            err3.gameObject.SetActive(false);
            err2.gameObject.SetActive(false);
        }
        else
        {
            string url = "https://gk43k.ldts.in/ExpApi/loginStudent1.php?s_id="+studentRollno+"&name="+studentName +"&std="+studentStd+"&div="+studentDiv;    
            StartCoroutine(GetRequest(url));
            Debug.Log(url);
        }
       
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(webRequest.error);
                err3.gameObject.SetActive(true);
                err1.gameObject.SetActive(false);
                err2.gameObject.SetActive(false);
            }
            else
            {
                if (webRequest.downloadHandler.text == "1")
                {
                    err3.gameObject.SetActive(false);
                    err1.gameObject.SetActive(false);
                    err2.gameObject.SetActive(false);
                    SceneManager.LoadScene("Menu");
                    //Debug.Log("Response: " + webRequest.downloadHandler.text);
                }
                else
                {
                    err3.gameObject.SetActive(false);
                    err1.gameObject.SetActive(false);
                    err2.gameObject.SetActive(true);
                }
            }
        }
    }
}
