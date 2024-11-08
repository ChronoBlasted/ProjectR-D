using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PlayerRole : MonoBehaviour
{
    [SerializeField] GameObject priestHands, demonHands;
    public AllRoles currentRole;
    
    public enum AllRoles
    {
        Priest,
        Demon
    }

    public void SetToDemon()
    {
        currentRole = AllRoles.Demon;
       /* priestHands.transform.DOScale(Vector3.zero, .2f).OnComplete(() =>
        {
            demonHands.transform.DOScale(Vector3.one, .2f);
        });*/
    }

    public void SetToPriest()
    {
        currentRole = AllRoles.Priest;
/*        demonHands.transform.DOScale(Vector3.zero, .2f).OnComplete(() =>
        {
            priestHands.transform.DOScale(Vector3.one, .2f);
        });*/
    }
}
