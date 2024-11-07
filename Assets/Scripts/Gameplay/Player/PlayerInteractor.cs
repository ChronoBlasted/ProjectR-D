using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInteractor : MonoBehaviour
{
    public UnityAction<PlayerInteractor> Interaction;    
    public Item interactObject,handObject;
    public Transform hand, Eye;
    
    [SerializeField] LayerMask myInteractionLayer;

    public void Update()
    {
        if (Physics.Raycast(Eye.transform.position, Eye.transform.forward, out RaycastHit hit, myInteractionLayer))
        {
            if (hit.collider.gameObject.TryGetComponent<Item>(out Item item))
            {
                if(item != interactObject)
                    interactObject = item;
            }

            else if (interactObject)
                interactObject = null;
        }
        else
        {
            if (interactObject)
                interactObject = null;                   
        }
    }

    public void SetObjectToInteract()
    {        
        if (interactObject)
        {                        
            Interaction = interactObject.myAction;
        }
        else if (handObject)
        {
            Interaction = handObject.myAction;
        }        
    }

    public void PickObject(Item obj)
    {
        handObject = obj;
        obj.transform.parent = hand;
        obj.transform.position = hand.position;        
    }
    public void DropObject(Item obj, Vector3 pos, Transform toParent = null)
    {
        obj.transform.SetParent(toParent,true);
        
        if (pos != Vector3.zero)
            obj.transform.position = pos;
        
        handObject = null;
    }

    public void TryInteraction()
    {
        SetObjectToInteract();

        if (!interactObject && !handObject)
            return;
       
        Interaction.Invoke(this);        
    }



}
