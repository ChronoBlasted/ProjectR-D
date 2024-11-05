using BaseTemplate.Behaviours;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoSingleton<PlayerManager>
{
    [field: SerializeField] public PlayerMovement PlayerMovement { get; protected set; }
    [field: SerializeField] public PlayerRole PlayerRole { get; protected set; }

    public void Init()
    {

    }
}
