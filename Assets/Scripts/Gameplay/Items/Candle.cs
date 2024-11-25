using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : PickableItem
{
    public Camp camp;

    public enum Camp 
    {
        Neutral,
        Priest,
        Demon
    }

}
