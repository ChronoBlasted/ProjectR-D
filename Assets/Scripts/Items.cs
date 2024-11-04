using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public Grab playerGrab;
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Grab>(out Grab player))
        {            
            if(playerGrab == null)
            {
                playerGrab = player;

                if (playerGrab.Interaction == null)
                {
                    playerGrab.Interaction += Interaction;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Grab>(out Grab player))
        {            
            playerGrab.Interaction -= Interaction;
            playerGrab = null;
        }        
    }

    public virtual void Interaction()
    {
        
    }

}
