using BaseTemplate.Behaviours;
using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraManager : MonoSingleton<CameraManager>
{
    public List<CinemachineVirtualCamera> cameras;

    CinemachineVirtualCamera currentCamera;
    [SerializeField] string firstCamera;

    CinemachineShake cinemachineShake;
    Coroutine shakeCoroutine;

    public CinemachineVirtualCamera CurrentCamera { get => currentCamera; }

    public void SwitchCamera(string cameraName)
    {
        if (currentCamera != null)
        {
            currentCamera.Priority = 0;
        }

        currentCamera = cameras.FirstOrDefault(cam => cam && cam.name == cameraName);

        if (currentCamera != null)
        {
            currentCamera.Priority = 1;

            cinemachineShake = currentCamera.GetComponent<CinemachineShake>();
        }
    }

    public void Init()
    {
        currentCamera = cameras.FirstOrDefault(cam => cam && cam.name == firstCamera);
        currentCamera.Priority = 1;
        cinemachineShake = currentCamera.GetComponent<CinemachineShake>();
    }

    public void ShakeCamera(float intensity = 4, float duration = .2f, float timeFade = .125f)
    {
        cinemachineShake.ShakeCamera(intensity, duration, timeFade);
    }


    void HandleStateChange(GameState newState)
    {
        switch (newState)
        {
            case GameState.Menu:
                HandleMenu();
                break;
            case GameState.Game:
                HandleGame();
                break;
            case GameState.End:
                HandleEnd();
                break;
            default:
                break;
        }
    }

    void HandleMenu()
    {
    }
    void HandleGame()
    {
    }
    void HandleEnd()
    {
    }
}
