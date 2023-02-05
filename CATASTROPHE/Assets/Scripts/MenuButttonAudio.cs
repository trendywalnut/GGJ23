using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButttonAudio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public AudioSource source;
    public AudioClip hover, click;

    public void OnClickPlay()
    {
        // GameManager.Instance.Reset();
    }

    public void OnClickHowToPlay()
    {
        // SceneManager.LoadScene( "HowToPlay" );
    }

    public void OnClickQuit()
    {
        // Application.Quit();
    }

    public void OnHoverSFX()
    {
        source.PlayOneShot(hover);
    }

    public void OnClickSFX()
    {
        source.PlayOneShot(click);
    }
}
