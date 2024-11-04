using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    public Grab playerGrab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Grab>(out Grab player))
        {
            playerGrab = player;
            playerGrab.Interaction += Interaction;
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
        if(playerGrab.handObject == null)
        {
            playerGrab.PickObject(gameObject);
            playerGrab.Interaction -= Interaction;
            return;
        }
        else if (playerGrab.handObject == gameObject)
        {
            playerGrab.DropObject(gameObject);
            return;
        }
        else
        {
            return;
        }
    }

}
