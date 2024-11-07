using System;
using UnityEngine;

public class PriestRoom : Room
{
    public override void OnTriggerEn(Collider other)
    {
        base.OnTriggerEn(other);

        if (other.gameObject.layer == 11)
        {
            PickableItem items = other.GetComponent<PickableItem>();

            if (Enum.IsDefined(typeof(PriestItems), (int)items.Data.Type) == false) return; // Si c'est pas un items de démon 

            if (items.Data.Type == ResourceToCollect) // Si cette items démon est dans la liste dans les missions
            {
                QuestManager.Instance.demonQuest.UpdateQuest(-1);

                if (QuestManager.Instance.priestQuest.amountToCollect <= 0)
                {
                    GameManager.Instance.UpdateStateToEnd();

                    UIManager.Instance.EndGameView.UpdateData(true);
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

            if (Enum.IsDefined(typeof(PriestItems), (int)items.Data.Type) == false) return; // Si c'est pas un items de démon 

            if (items.Data.Type == ResourceToCollect) // Si cette items démon est dans la liste dans les missions
            {
                QuestManager.Instance.demonQuest.UpdateQuest(1);
            }
        }
    }
}
