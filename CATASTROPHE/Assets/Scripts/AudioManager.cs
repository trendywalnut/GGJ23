using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public AudioSource gameSFX;

    public void SFXPlayer (AudioClip SFX)
    {
        gameSFX.clip = SFX;
        gameSFX.Play();
    }
}
