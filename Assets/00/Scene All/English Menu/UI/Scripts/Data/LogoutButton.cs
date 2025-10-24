using UnityEngine;

public class LogoutButton : MonoBehaviour
{
    [Header("Panels to toggle")]
    public GameObject loginPanel;     // assign your login/root screen
    public GameObject adminPanel;     // assign Admin main panel root
    public GameObject teacherPanel;   // assign Teacher main panel root
    public GameObject studentPanel;   // assign Student main panel root

    [Header("Optional")]
    public bool reloadSceneOnLogout = false;
    public string loginSceneName = "Login"; // only used if reloadSceneOnLogout = true

    public void OnLogoutClick()
    {
        if (AppSession.I != null)
            AppSession.I.Logout();

        // Option A: just toggle panels in current scene
        if (!reloadSceneOnLogout)
        {
            if (adminPanel) adminPanel.SetActive(false);
            if (teacherPanel) teacherPanel.SetActive(false);
            if (studentPanel) studentPanel.SetActive(false);
            if (loginPanel) loginPanel.SetActive(true);
        }
        else
        {
            // Option B: reload a clean login scene
            UnityEngine.SceneManagement.SceneManager.LoadScene(loginSceneName);
        }

        Debug.Log("[Logout] User logged out  back to login");
    }
}
