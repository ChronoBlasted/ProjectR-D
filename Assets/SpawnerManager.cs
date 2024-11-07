using BaseTemplate.Behaviours;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoSingleton<SpawnerManager>
{
    [SerializeField] List<Transform> playerSpawnPoint = new List<Transform>();
    public void Init()
    {
        PlayerManager.Instance.transform.position = playerSpawnPoint[Random.Range(0, playerSpawnPoint.Count)].position;
        PlayerManager.Instance.transform.rotation = playerSpawnPoint[Random.Range(0, playerSpawnPoint.Count)].rotation;
    }
}
