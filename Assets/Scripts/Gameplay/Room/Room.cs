using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Room : MonoBehaviour
{
    public ResourceType ResourceToCollect;

    public virtual void OnTriggerEn(Collider other)
    {

    }


    public virtual void OnTriggerEx(Collider other)
    {

    }

    void OnTriggerEnter(Collider other)
    {
        OnTriggerEn(other);
    }

    void OnTriggerExit(Collider other)
    {
        OnTriggerEx(other);
    }
}
