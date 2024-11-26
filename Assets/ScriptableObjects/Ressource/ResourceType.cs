using System;

public enum ResourceType
{
    None = 0,
    Candles = 1,
    Cross = 2,

    ______DEMON______ = 99,
    DemonHead = 101,

    ______PRIEST______ = 199,
    Bible = 201,

}

public enum DemonItems
{
    None = ResourceType.None,

    Candles = ResourceType.Candles,
    //Cross = ResourceType.Cross,

    //DemonHead = ResourceType.DemonHead,
}

public enum PriestItems
{
    None = ResourceType.None,

    Candles = ResourceType.Candles,
    //Cross = ResourceType.Cross,

    //Bible = ResourceType.Bible,
}