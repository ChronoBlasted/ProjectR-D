using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Door : Item
{
    public Item Key;
    [SerializeField] bool isOpen, isLocked;
    private Collider collider;
    float baseY;

    public override void Awake()
    {
        baseY = transform.rotation.eulerAngles.y ; 
        base.Awake();
        collider = GetComponent<Collider>();
    }

    public override void Interaction(PlayerInteractor player)
    {
        base.Interaction(player);

        if (isOpen)
        {
            Close();
        }

        else
        {
            if (Key != null)
            {
                if (player.handObject == Key)
                {
                    if (LockUnlock() == false)
                        Open();
                    return;
                }

                if (!isLocked)
                    Open();
            }
            else
            {
                Open();
            }
        }
    }

    void ToggleCollision(bool b)
    {
        collider.enabled = b;
    }


    public bool LockUnlock()
    {
        isLocked = !isLocked;
        return isLocked;
    }

    public void Open()
    {
        transform.DOKill();

        ToggleCollision(false);
        transform.DORotate(new Vector3(0, baseY + 90, 0), 1).OnComplete(() =>
        {
            ToggleCollision(true);
        });
        isOpen = true;
    }
    public void Close()
    {
        transform.DOKill();
        ToggleCollision(false);
        transform.DORotate(new Vector3(0, baseY, 0), 1).OnComplete(() =>
        {
            ToggleCollision(true);
        });
        isOpen = false;
    }

}
