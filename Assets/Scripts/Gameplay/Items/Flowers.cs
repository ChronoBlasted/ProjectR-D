using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flowers : Item
{
    [SerializeField] Item hiddenObject;
    [SerializeField] Transform objectPos;

    public override void Interaction(PlayerInteractor player)
    {
        if(player.handObject)
        {
           if(hiddenObject)
           {
                return;
           }

            Hide(player.handObject);
            player.handObject = null;

            return;
        }

        Search();
    }

    void Hide(Item toHide)
    {
        hiddenObject = toHide;
        toHide.transform.SetParent(null);
        toHide.transform.position = transform.position;
        toHide.gameObject.SetActive(false);
    }

    void Search()
    {
        if(hiddenObject)
        {
            hiddenObject.gameObject.SetActive(true);
            hiddenObject.transform.position = objectPos.position;
            hiddenObject = null;
        }
    }

}
