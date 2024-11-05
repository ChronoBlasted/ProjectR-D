using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pickable : MonoBehaviour
{
    public PlayerInteractor playerGrab;
    public UnityAction<GameObject> myAction;
    public GameObject myObject;
    
    
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.TryGetComponent<PlayerInteractor>(out PlayerInteractor player))
    //    {
    //        playerGrab = player;
    //        //playerGrab.Interaction = myAction;
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.TryGetComponent<PlayerInteractor>(out PlayerInteractor player))
    //    {
    //        if(player.handObject != myObject)
    //        {
    //            playerGrab.Interaction = null;                
    //        }
    //            playerGrab = null;
    //    }
    //}

   

    
}
