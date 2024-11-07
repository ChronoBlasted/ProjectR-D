using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : PickableItem
{
    //[SerializeField] protected Rigidbody rB;

    //public override void Interaction(PlayerInteractor player)
    //{
    //    if (player.handObject == null)
    //    {
    //        ChangePhysics(true);
    //        player.PickObject(this);
    //        return;
    //    }
    //    else if (player.handObject == this)
    //    {
    //        Ray ray = new Ray(player.Eye.transform.position, player.Eye.transform.forward);
    //        if (Physics.Raycast(ray, out RaycastHit hit, 1))
    //            player.DropObject(this, hit.point, hit.transform);
    //        else
    //            player.DropObject(this, Vector3.zero);

    //        ChangePhysics(false);

    //        return;
    //    }
    //    else
    //    {
    //        return;
    //    }
    //}
    //public void ChangePhysics(bool b)
    //{
    //    if (b == true)
    //    {
    //        rB.constraints = RigidbodyConstraints.FreezeAll;
    //    }
    //    else
    //    {
    //        rB.constraints = RigidbodyConstraints.None;
    //    }
    //}
}
