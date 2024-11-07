using BaseTemplate.Behaviours;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class QuestManager : MonoSingleton<QuestManager>
{
    public Quest demonQuest;
    public Quest priestQuest;

    [SerializeField] Room priestRoom, demonRoom;

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
    }

    public Quest GetRandomQuestBringToRoom(bool isPriestQuest)
    {
        return new Quest
        {
            amountToCollect = Random.Range(1, 5),
            resourceToCollect = isPriestQuest ?
            (ResourceType)Enum.Parse(typeof(ResourceType), Enum.GetNames(typeof(PriestItems)).Skip(1).Randomize().First()) :
            (ResourceType)Enum.Parse(typeof(ResourceType), Enum.GetNames(typeof(DemonItems)).Skip(1).Randomize().First()),
        };
    }
}


