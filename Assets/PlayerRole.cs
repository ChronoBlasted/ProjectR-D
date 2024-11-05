using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PlayerRole : MonoBehaviour
{
    [SerializeField] GameObject priestHands, demonHands;

    public void SetToDemon()
    {
        priestHands.transform.DOScale(Vector3.zero, .2f).OnComplete(() =>
        {
            demonHands.transform.DOScale(Vector3.one, .2f);
        });
    }

    public void SetToPriest()
    {
        demonHands.transform.DOScale(Vector3.zero, .2f).OnComplete(() =>
        {
            priestHands.transform.DOScale(Vector3.one, .2f);
        });
    }

    public void RotateCameraRandomly()
    {
        //PlayerManager.Instance.PlayerMovement.
    }
}
