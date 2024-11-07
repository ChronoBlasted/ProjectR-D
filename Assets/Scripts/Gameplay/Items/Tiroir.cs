using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tiroir : Item
{
    private bool isOpen;
    [SerializeField] Transform tiroir;
    public override void Interaction(PlayerInteractor player)
    {
        if (player.handObject)
        {
            player.handObject.Interaction(player);
            return;
        }
        else
        {
            if (isOpen)
            {
                tiroir.DOKill();
                tiroir.DOLocalMoveZ(0.075f, 1);
            }
            else
            {
                tiroir.DOKill();
                tiroir.DOLocalMoveZ(.8f, 1);
            }
            isOpen = !isOpen;
        }
    }


}
