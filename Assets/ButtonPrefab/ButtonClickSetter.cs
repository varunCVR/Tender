using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonClickSetter : MonoBehaviour
{

    string sceneName;

    private void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
    }

    public void LoadNextScene()
    {
        TheManager.instance.LoadNextScene();
    }
    public void LoadPreviousScene()
    {
        TheManager.instance.LoadPreviousScene();
    }

    public void ReloadScene()
    {
        TheManager.instance.ResetScene(sceneName);
        
    }
    public void Quiting()
    {
        TheManager.instance.Quiting();
    }
        
}
