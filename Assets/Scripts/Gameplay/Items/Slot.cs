using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : Item
{
    public bool toggle;
    Item Condition;
    public Candle.Camp campComp;
    public Sanctuaire MyRitual;

    public void SetBool(bool b)
    {
        toggle = b;
    }
    public override void Interaction(PlayerInteractor player)
    {
        base.Interaction(player);

        if (player.handObject as Candle)
        {
            Candle _candle = (Candle)player.handObject;

            if (_candle.camp == campComp)
            {
                player.DropObject(player.handObject, transform.position, transform);
                print("MAKE THE RITUAL :" + MyRitual.MakeRitual());
            }
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<Candle>(out Candle _candle))
        {
            if(_candle.camp == campComp)
            {
                toggle = true; 
            }
        }
    }
}
