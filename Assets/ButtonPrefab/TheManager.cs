using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheManager : MonoBehaviour
{
    public static TheManager instance;
    int sceneValue = 1;
    bool isLoadNextAndPrevScene = true;
    int totalScenes;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        totalScenes = SceneManager.sceneCountInBuildSettings + 1;
    }

    public void ResetScene(string sceneNameToReload)
    {
        SceneManager.LoadScene(sceneNameToReload);
    }
    public void Quiting()
    {
        Application.Quit();
    }

    public void LoadNextScene()
    {

        if (isLoadNextAndPrevScene)
        {

            if (sceneValue > totalScenes)
            {
                sceneValue = 1;
                SceneManager.LoadScene(sceneValue);

            }
            else
            {
                sceneValue++;
                SceneManager.LoadScene(sceneValue);
            }


        }


    }
    public void LoadPreviousScene()
    {
        if (sceneValue > 0 && isLoadNextAndPrevScene)
        {
            sceneValue--;
            SceneManager.LoadScene(sceneValue);
        }


    }
}
