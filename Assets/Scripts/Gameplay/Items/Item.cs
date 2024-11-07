using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Item : MonoBehaviour
{
    public UnityAction<PlayerInteractor> myAction;
    public List<ActionName> lst_Actions;
    public void Awake()
    {
        myAction += Interaction;
    }
    public void OnDestroy()
    {
        myAction = null;
    }    


    [Serializable]
    public class ActionName
    {
        public Item item = null;
        public bool global;
        public string name;
    }


    public virtual string SetActionDebug(Item onHand = null)
    {
        foreach (var v in lst_Actions)
        {
            if(v.item == onHand)
            {
                return v.name;
            }
            if (v.item == onHand)
            {

            }
        }

        return null;

    }

    public virtual void Interaction(PlayerInteractor player)
    {

    }

}
