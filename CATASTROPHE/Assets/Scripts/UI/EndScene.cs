using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    private VideoPlayer vp;

    void Start()
    {
        vp = GetComponent<VideoPlayer>();
        vp.loopPointReached += LoadScene; 
    }

    void LoadScene(VideoPlayer vp)
    {
        StartCoroutine(LoadSceneTimer());
    }

    IEnumerator LoadSceneTimer()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Title Screen");
    }
}
