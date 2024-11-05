using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Items
{

    
    public override void Interaction(PlayerInteractor player)
    {
        if (player.handObject == null)
        {
            ChangePhysics(true);
            player.PickObject(this);
            return;
        }
        else if (player.handObject == this)
        {
            Ray ray = new Ray(player.Eye.transform.position, player.Eye.transform.forward);
            if(Physics.Raycast(ray,out RaycastHit hit,1))
                player.DropObject(this, hit.point);
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
        if (b == true)
        {
            Rb2D.constraints = RigidbodyConstraints.FreezeAll;
        }
        else
        {
            Rb2D.constraints = RigidbodyConstraints.None;
        }
    }
}
