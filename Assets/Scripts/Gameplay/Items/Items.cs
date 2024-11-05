using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Items : MonoBehaviour
{
    public UnityAction<PlayerInteractor> myAction;
    [SerializeField] protected Rigidbody Rb2D;
    public void Awake()
    {
        myAction += Interaction;
    }
    public void OnDestroy()
    {
        myAction = null;
    }
    #region WithTrigger
    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.TryGetComponent<PlayerInteractor>(out PlayerInteractor player))
    //    {            
    //        if(playerGrab == null)
    //        {
    //            playerGrab = player;

    //            if (playerGrab.Interaction == null)
    //            {
    //                playerGrab.Interaction = myAction;
    //            }
    //        }
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.TryGetComponent<PlayerInteractor>(out PlayerInteractor player))
    //    {            
    //        if (playerGrab.Interaction == myAction)
    //        playerGrab.Interaction = null;

    //        playerGrab = null;
    //    }        
    //}
    #endregion

    public virtual void Interaction(PlayerInteractor player)
    {
        
    }

}
