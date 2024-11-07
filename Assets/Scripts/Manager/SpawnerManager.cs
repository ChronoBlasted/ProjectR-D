using BaseTemplate.Behaviours;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerManager : MonoSingleton<SpawnerManager>
{
    [SerializeField] GameObject demonKey, priestKey;
    [SerializeField] List<Transform> playerSpawnPoint = new List<Transform>();
    [SerializeField] List<Transform> keySpawnPoint = new List<Transform>();
    [SerializeField] List<ItemInWorld> itemsInWorld = new List<ItemInWorld>();

    public void Init()
    {
        var randomSpawnPoint = playerSpawnPoint[Random.Range(0, playerSpawnPoint.Count)];

        PlayerManager.Instance.transform.position = randomSpawnPoint.position;
        PlayerManager.Instance.transform.rotation = randomSpawnPoint.rotation;

        var demonKeySpawn = keySpawnPoint[Random.Range(0, playerSpawnPoint.Count)];

        keySpawnPoint.Remove(demonKeySpawn);

        var priestKeySpawn = keySpawnPoint[Random.Range(0, playerSpawnPoint.Count)];

        demonKey.transform.position = demonKeySpawn.position;
        demonKey.transform.rotation = demonKeySpawn.rotation;
        demonKey.transform.parent = demonKeySpawn;

        priestKey.transform.position = priestKeySpawn.position;
        priestKey.transform.rotation = priestKeySpawn.rotation;
        priestKey.transform.parent = priestKeySpawn;

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