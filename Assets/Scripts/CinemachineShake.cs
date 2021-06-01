using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineShake : MonoBehaviour
{
    public static CinemachineShake cm { get; private set; }
    CinemachineVirtualCamera virtualCamera;
    CinemachineBasicMultiChannelPerlin perlin;
    private float shakeTimer;

    private void Awake()
    {
        cm = this;
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        perlin = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void ShakeCamera(float intensity, float time)
    {
        perlin.m_AmplitudeGain = intensity;
        shakeTimer = time;
    }

    private void Update()
    {
        shakeTimer -= Time.deltaTime;
        if (shakeTimer <= 0)
            perlin.m_AmplitudeGain = 0f;
    }
}
