using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Items
{
    public GameObject Key;
    [SerializeField] bool isOpen;

    public override void Interaction()
    {
        base.Interaction();

        if(playerGrab.handObject == Key)
        {
            if (isOpen)
            {
                isOpen = !isOpen;
            }
            else
            {
                isOpen = !isOpen;
            }
        }
    }


}
