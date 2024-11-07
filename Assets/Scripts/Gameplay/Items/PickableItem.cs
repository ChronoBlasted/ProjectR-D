using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class PickableItem : Item
{
    [SerializeField] protected Rigidbody rB;
    [SerializeField] Vector3 V3;

    [SerializeField] ResourceObject data;
    public ResourceObject Data { get => data; set => data = value; }

    public override void Interaction(PlayerInteractor player)
    {
        if (player.handObject == null)
        {
            player.PickObject(this);
            ChangePhysics(true);

            return;
        }
        else if (player.handObject == this)
        {
            Ray ray = new(player.Eye.transform.position, player.Eye.transform.forward);

            if (Physics.Raycast(ray, out RaycastHit hit, 1))
                player.DropObject(this, hit.point, hit.transform);
            else
                player.DropObject(this, Vector3.zero);

            ChangePhysics(false);

            return;
        }
        else
        {
            return;
        }
    }
    public void ChangePhysics(bool b)
    {
        transform.DOKill();
        transform.DORotate(V3, 0.5f);

        if (b == true)
        {
            rB.constraints = RigidbodyConstraints.FreezeAll;
        }
        else
        {
            rB.constraints = RigidbodyConstraints.None;
        }
    }
}
