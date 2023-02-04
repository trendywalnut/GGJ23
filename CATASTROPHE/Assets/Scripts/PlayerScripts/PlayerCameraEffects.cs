using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerCameraEffects : MonoBehaviour
{
    public static PlayerCameraEffects Instance { get; private set; }

    private CinemachineVirtualCamera virtualCamera;

    private float cameraOrthoSize;

    private float shakeTimer;
    private float shakeTimerMax;
    private float startingShakeIntensity;

    private float punchTimer;
    private float punchTimerMax;
    private float startingPunchIntensity;

    private void Awake()
    {
        Instance = this;
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        cameraOrthoSize = virtualCamera.m_Lens.OrthographicSize;
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

    public void PunchCamera(float intensity, float time)
    {
        virtualCamera.m_Lens.OrthographicSize -= intensity;

        startingPunchIntensity = virtualCamera.m_Lens.OrthographicSize - intensity;
        punchTimerMax = time;
        punchTimer = time;
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
                
                perlin.m_AmplitudeGain = Mathf.Lerp(startingShakeIntensity, 0f, (1 - (shakeTimer/shakeTimerMax)));

            }
        }

        if (punchTimer > 0)
        {
            punchTimer -= Time.deltaTime;
            if (punchTimer <= 0)
            {
                virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(startingPunchIntensity, cameraOrthoSize, (1 - (punchTimer / punchTimerMax)));
            }
        }
    }

}
