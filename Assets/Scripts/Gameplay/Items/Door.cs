using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Door : Items
{
    public Items Key;
    [SerializeField] bool isOpen;

    public override void Interaction(PlayerInteractor player)
    {
        base.Interaction(player);

        if(player.handObject == Key)
        {
            if (isOpen)
            {
                transform.DOKill();
                transform.DORotate(new Vector3 (0, 90, 0) , 1);               
            }
            else
            {
                transform.DOKill();
                transform.DORotate(new Vector3(0, 0, 0), 1);
            }
                isOpen = !isOpen;
        }
    }




}
