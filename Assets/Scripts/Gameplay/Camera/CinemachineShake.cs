using Cinemachine;
using DG.Tweening;
using UnityEngine;

public class CinemachineShake : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera cinemachineVirtualCamera;

    Tweener _shakeTween;
    CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin;

    private void Awake()
    {
        cinemachineBasicMultiChannelPerlin = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void ShakeCamera(float intensity, float duration, float timeFade)
    {
        if (_shakeTween.IsActive()) _shakeTween.Kill();

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;

        _shakeTween = DOVirtual.Float(cinemachineBasicMultiChannelPerlin.m_AmplitudeGain, 0, timeFade, x => cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = x).SetDelay(duration);
    }
}