using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Item : MonoBehaviour
{
    public UnityAction<PlayerInteractor> myAction;
    
    public void Awake()
    {
        myAction += Interaction;
    }
    public void OnDestroy()
    {
        myAction = null;
    }    

    public virtual void Interaction(PlayerInteractor player)
    {
        
    }

}
