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
            PickableItem items = other.GetComponent<PickableItem>();

            if (Enum.IsDefined(typeof(DemonItems), (int)items.Data.Type) == false) return; // Si c'est pas un items de d�mon 

            if (items.Data.Type == ResourceToCollect) // Si cette items d�mon est dans la liste dans les missions
            {
                Candle candle = other.GetComponent<Candle>();

                if (candle.camp == Candle.Camp.Priest) return;

                QuestManager.Instance.demonQuest.UpdateQuest(-1);

                if (QuestManager.Instance.demonQuest.amountToCollect <= 0)
                {
                    UIManager.Instance.EndGameView.UpdateData(false);

                    GameManager.Instance.UpdateStateToEnd();
                }
            }
        }
    }

    public override void OnTriggerEx(Collider other)
    {
        base.OnTriggerEx(other);

        if (other.gameObject.layer == 11)
        {
            PickableItem items = other.GetComponent<PickableItem>();

            if (Enum.IsDefined(typeof(DemonItems), (int)items.Data.Type) == false) return; // Si c'est pas un items de d�mon 

            if (items.Data.Type == ResourceToCollect) // Si cette items d�mon est dans la liste dans les missions
            {
                Candle candle = other.GetComponent<Candle>();

                if (candle.camp == Candle.Camp.Priest) return;

                QuestManager.Instance.demonQuest.UpdateQuest(1);
            }
        }
    }

}
