using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonRoom : Room
{

    public override void OnTriggerEn(Collider other)
    {
        base.OnTriggerEn(other);

        if (other.gameObject.layer == 11)
        {
            Items items = other.GetComponent<Items>();

            if (Enum.IsDefined(typeof(DemonItems), (int)items.Data.Type) == false) return; // Si c'est pas un items de d�mon 

            if (items.Data.Type == ResourceToCollect) // Si cette items d�mon est dans la liste dans les missions
            {
                QuestManager.Instance.demonQuest.amountToCollect--;
            }
        }
    }
}
