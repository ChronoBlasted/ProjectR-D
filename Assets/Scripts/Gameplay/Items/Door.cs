using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Door : Item
{
    public Item Key;
    [SerializeField] bool isOpen, isLocked;

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

    public void LockUnlock()
    {
        if (isOpen)
        {

        }
    }



}
