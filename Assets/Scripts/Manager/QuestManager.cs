using BaseTemplate.Behaviours;
using System;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class QuestManager : MonoSingleton<QuestManager>
{
    public Quest demonQuest;
    public Quest priestQuest;

    [SerializeField] Room priestRoom, demonRoom;
    [SerializeField] int extraQuestItem = 2;

    public void Init()
    {
        SetupQuests();
    }

    public void SetupQuests()
    {
        demonQuest = GetRandomQuestBringToRoom(false);
        priestQuest = GetRandomQuestBringToRoom(true);

        demonRoom.ResourceToCollect = demonQuest.resourceToCollect;
        priestRoom.ResourceToCollect = priestQuest.resourceToCollect;

        UIManager.Instance.GameView.UpdateQuest(priestQuest, demonQuest);

        if (demonQuest.resourceToCollect == priestQuest.resourceToCollect)
        {
            SpawnerManager.Instance.SetupItem(demonQuest.resourceToCollect, priestQuest.amountToCollect + demonQuest.amountToCollect + extraQuestItem);
        }
        else
        {
            SpawnerManager.Instance.SetupItem(demonQuest.resourceToCollect, demonQuest.amountToCollect + extraQuestItem);
            SpawnerManager.Instance.SetupItem(priestQuest.resourceToCollect, demonQuest.amountToCollect + extraQuestItem);
        }
    }

    public Quest GetRandomQuestBringToRoom(bool isPriestQuest)
    {
        return new Quest
        {
            amountToCollect = Random.Range(1, 3),
            resourceToCollect = isPriestQuest ?
            (ResourceType)Enum.Parse(typeof(ResourceType), Enum.GetNames(typeof(PriestItems)).Skip(1).Randomize().First()) :
            (ResourceType)Enum.Parse(typeof(ResourceType), Enum.GetNames(typeof(DemonItems)).Skip(1).Randomize().First()),
        };
    }
}


