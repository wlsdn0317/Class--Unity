using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonCtrl : MonoBehaviour
{
    [SerializeField]
    GameObject menuPanel;

    public void OnClickPlay()
    {
        SceneManager.LoadScene(1);
    }

    public void OnClickStart()
    {
        SceneManager.LoadScene(0);
    }

    public void OnClickExit()
    {
        Application.Quit();
    }

    public void OnClickPose()
    {
        menuPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OnClickReplay()
    {
        Time.timeScale = 1f;
        menuPanel.SetActive(false);
    }
}
