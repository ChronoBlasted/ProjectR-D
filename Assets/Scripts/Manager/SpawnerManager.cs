using BaseTemplate.Behaviours;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerManager : MonoSingleton<SpawnerManager>
{
    [SerializeField] List<Transform> playerSpawnPoint = new List<Transform>();
    [SerializeField] List<ItemInWorld> itemsInWorld = new List<ItemInWorld>();

    public void Init()
    {
        PlayerManager.Instance.transform.position = playerSpawnPoint[Random.Range(0, playerSpawnPoint.Count)].position;
        PlayerManager.Instance.transform.rotation = playerSpawnPoint[Random.Range(0, playerSpawnPoint.Count)].rotation;
    }

    public void SetupItem(ResourceType Type, int amount)
    {
        var item = itemsInWorld.FirstOrDefault(x => x.Type == Type);
        if (item == null || item.GameObjects.Count == 0) return;

        var itemsToActivate = item.GameObjects.Randomize().Take(amount).ToList();

        foreach (var gameObject in item.GameObjects)
        {
            gameObject.SetActive(itemsToActivate.Contains(gameObject));
        }
    }
}

[Serializable]
public class ItemInWorld
{
    public ResourceType Type;
    public List<GameObject> GameObjects;
}