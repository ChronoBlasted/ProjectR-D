using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Grab : MonoBehaviour
{
    public UnityAction Interaction;
    public GameObject handObject;
    [SerializeField] Transform hand;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (Interaction == null)
            {
                if (handObject)
                {
                    DropObject(handObject);
                }
            }            
            else
                Interaction.Invoke();
        }
    }
    public void PickObject(GameObject obj)
    {
        handObject = obj;
        obj.transform.parent = hand;
        obj.transform.position = hand.position;
    }
    public void DropObject(GameObject obj)
    {
        obj.transform.parent = null; 
        handObject = null;
    }
}
