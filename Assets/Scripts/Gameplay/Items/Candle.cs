using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : PickableItem
{
    public Type type;

    public enum Type
    {
        Neutral,
        Priest,
        Demon
    }



}
