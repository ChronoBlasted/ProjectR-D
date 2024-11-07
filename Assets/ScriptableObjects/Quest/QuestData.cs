using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class QuestData : ScriptableObject
{
    public QuestType Type;
    public int Amount;
}

public enum QuestType
{
    None,
    UnlockAccess,
    BringToRoom, 
    FinishGame
}