using UnityEngine;
using UnityEngine.SceneManagement;
using static OVRInput;

public class ResetAndScene : MonoBehaviour
{

    public string nextScene;

    void Update()
    {
        ResetButton();
        NextScene();
        Quit();

    }

    private void ResetButton()
    {
        if (OVRInput.GetUp(OVRInput.RawButton.B))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void NextScene()
    {
        if (OVRInput.GetUp(OVRInput.RawButton.Y))
        {
            SceneManager.LoadScene(nextScene);
        }
            
    }

    private void Quit()
    {
        if (OVRInput.GetUp(OVRInput.RawButton.X))
        {
            Application.Quit();
        }
    }
}
