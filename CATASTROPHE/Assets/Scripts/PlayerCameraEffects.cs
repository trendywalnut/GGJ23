using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerCameraEffects : MonoBehaviour
{
    public static PlayerCameraEffects Instance { get; private set; }

    private CinemachineVirtualCamera virtualCamera;

    private float shakeTimer;
    private float shakeTimerMax;
    private float startingShakeIntensity;

    private void Awake()
    {
        Instance = this;
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    public void ShakeCamera (float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin perlin = 
            virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        
        perlin.m_AmplitudeGain = intensity;

        startingShakeIntensity = intensity;
        shakeTimerMax = time;
        shakeTimer = time;
    }

    private void Update()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            if (shakeTimer <= 0f)
            {
                CinemachineBasicMultiChannelPerlin perlin = 
                    virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                
                perlin.m_AmplitudeGain = 0f;
                Mathf.Lerp(startingShakeIntensity, 0f, (1 - (shakeTimer/shakeTimerMax)));

            }
        }
    }

}
