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
