using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] private string gameSceneName;
    [SerializeField] private GameObject credits;

    public void PlayButton()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void OpenCredits()
    {
        credits.SetActive(true);
    }

    public void CloseCredits()
    {
        credits.SetActive(false);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
