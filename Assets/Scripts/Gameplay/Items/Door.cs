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

        if (isOpen)
        {
            Close();
        }

        else
        {
            if (player.handObject == Key)
            {
                if (LockUnlock() == false)
                    Open();
                return;
            }
        }
    }

    public bool LockUnlock()
    {
        isLocked = !isLocked;
        return isLocked;
    }

    public void Open()
    {
        transform.DOKill();
        transform.DORotate(new Vector3(0, 90, 0), 1);
        isOpen = true;
    }
    public void Close()
    {
        transform.DOKill();
        transform.DORotate(new Vector3(0, 0, 0), 1);
        isOpen = false;
    }

}
