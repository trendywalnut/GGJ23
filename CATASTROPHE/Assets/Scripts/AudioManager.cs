using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    void Start()
    {
        instance = this;
    }

    public AudioSource playerSFX;
    public AudioSource enemySFX;

    public void PlayerSFXPlayer (AudioClip SFX)
    {
        playerSFX.clip = SFX;
        playerSFX.Play();
    }

    public void EnemySFXPlayer (AudioClip SFX)
    {
        enemySFX.clip = SFX;
        enemySFX.Play();
    }
}
