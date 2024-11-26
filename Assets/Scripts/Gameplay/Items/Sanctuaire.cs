using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sanctuaire : MonoBehaviour
{
    public List<MySlot> slots;

    //public void SetThe(int nb) //nombre de 
    //{ 
    //    for(int i = nb; i>0;i--)
    //    {

    //    }

    //}


    public bool MakeRitual()
    {
        foreach(MySlot _slot in slots)
        {
            if(_slot.active)
            {
                if(_slot.slot.transform.childCount <= 0)
                    return false;
            }
        }
        return true;
    }
    

}
[Serializable]
public class MySlot
{
    public Slot slot;
    public bool active;
}
