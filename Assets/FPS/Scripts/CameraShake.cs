using Unity.Cinemachine;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance;
    //private CinemachineBasicMultiChannelPerlin cameraNoiseComponent;
    private CinemachineCamera cinemachineCamera;
    private float shakeTimer;

    private void Awake()
    {
        //cameraNoiseComponent = GetComponent<CinemachineBasicMultiChannelPerlin>();
        cinemachineCamera = GetComponent<CinemachineCamera>();
        instance = this;
    }

    public void CameraShakeFrequency(float amplitude, float time)
    {
        //cameraNoiseComponent.AmplitudeGain = amplitude;
        CinemachineBasicMultiChannelPerlin cameraNoiseComponent = cinemachineCamera.GetComponent<CinemachineBasicMultiChannelPerlin>();
        cameraNoiseComponent.AmplitudeGain = amplitude;
        shakeTimer = time;
    }

    private void Update()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            if (shakeTimer <= 0)
            {
                CinemachineBasicMultiChannelPerlin cameraNoiseComponent = cinemachineCamera.GetComponent<CinemachineBasicMultiChannelPerlin>();
                cameraNoiseComponent.AmplitudeGain = 0;
                shakeTimer = 0;
            }
        }
    }
}
