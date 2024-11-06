using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SideQuestLayout : MonoBehaviour
{
    [SerializeField] Image cornerImg;
    [SerializeField] CanvasGroup cg;

    public void SetActive(bool isActive, float duration = .2f)
    {
        if (isActive)
        {
            cornerImg.DOFade(.75f, duration);
            cg.DOFade(1, duration);
            transform.DOScale(1f, duration).SetEase(Ease.InOutBack);
        }
        else
        {
            cornerImg.DOFade(0, duration);
            cg.DOFade(0.5f, duration);
            transform.DOScale(.8f, duration).SetEase(Ease.InOutBack);
        }

    }

    public void Init()
    {

    }
}
