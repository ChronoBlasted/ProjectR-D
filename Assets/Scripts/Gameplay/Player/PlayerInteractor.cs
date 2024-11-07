using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//using UnityEngine.UI;
using TMPro;

public class PlayerInteractor : MonoBehaviour
{
    public UnityAction<PlayerInteractor> Interaction;    
    public Item interactObject,handObject;
    public Transform hand, Eye;
    public TextMeshProUGUI interactionText;
    [SerializeField] LayerMask myInteractionLayer;
    Ray ray;
    public void Awake()
    {
        //ray = new Ray(Eye.transform.position, Eye.transform.forward);
    }

    public void Update()
    {   
        if (Physics.Raycast(Eye.transform.position, Eye.transform.forward, out RaycastHit hit, 5, myInteractionLayer))
        {
            if (hit.collider.gameObject.TryGetComponent<Item>(out Item item)) // Si l'objet à un script
            {
                if (item != interactObject)
                {
                    interactObject = item;
                    
                    if(handObject)
                        interactionText.text = item.SetActionDebug(handObject);
                    else
                        interactionText.text = item.SetActionDebug();

                }
            }
            else// Si l'objet est du décor
            {

                interactObject = null;
                    if(handObject)
                        interactionText.text = handObject.SetActionDebug(handObject);
                    else
                        interactionText.text = null;
            } 
        }
        else // Si on vise dans le vide
        {
            if (interactObject)
                interactObject = null;

                interactionText.text = null;
        }
    }

    public void SetInteractText(string str)
    { 
    
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
