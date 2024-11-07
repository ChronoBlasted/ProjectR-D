using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public int amountToCollect;
    public ResourceType resourceToCollect;

    public void UpdateQuest(int amountToAdd)
    {
        amountToCollect += amountToAdd;

        if (amountToCollect <= 0)
        {
            // Quest Complete
        }
    }
}
