using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{
    public int amountToCollect;
    public ResourceType resourceToCollect;

    public void UpdateQuest(int amountToAdd)
    {
        amountToCollect += amountToAdd;

        if (amountToCollect <= 0)
        {
            amountToCollect = 0;
        }

        UIManager.Instance.GameView.UpdateQuest();
    }
}
