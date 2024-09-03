using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static OVRInput;

public class Manaager : MonoBehaviour
{
    public GameObject skull;
    public GameObject engine;

    private void Update()
    {
        ButtonClick();
    }
    public void ButtonClick()
    {
        if (OVRInput.GetUp(OVRInput.RawButton.X))
        {
            HideShow();
        }
        else if (OVRInput.GetUp(OVRInput.RawButton.B))
        {
            ResetGame();
        }
    }

    private void HideShow()
    {
        if (skull.activeSelf)
        {
            skull.SetActive(false);
            engine.SetActive(true);
        }
        else
        {
            skull.SetActive(true);
            engine.SetActive(false);
        }
    }

    private void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
