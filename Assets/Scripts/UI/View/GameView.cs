using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameView : View
{
    [SerializeField] TMP_Text timerTurnTxt;
    [SerializeField] SideQuestLayout priestQuestLayout, demonQuestLayout;

    Tweener timerTween;

    public void UpdateQuest(Quest priestBringToQuest, Quest demonBringToQuest)
    {
        priestQuestLayout.Init(priestBringToQuest);
        demonQuestLayout.Init(demonBringToQuest);
    }

    public IEnumerator UpdateTimer(int totalSeconds)
    {
        if (timerTween != null)
        {
            timerTween.Kill();
            timerTurnTxt.DOFade(1, 0);
        }

        while (totalSeconds >= 0)
        {
            int minutes = totalSeconds / 60;
            int seconds = totalSeconds % 60;

            timerTurnTxt.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            yield return new WaitForSeconds(1f);

            totalSeconds--;
        }

        RoleManager.Instance.ChangeRole();

        timerTurnTxt.text = "PLAYER CHANGES";

        timerTween = timerTurnTxt.DOFade(.5f, .2f).SetLoops(-1, LoopType.Yoyo);
    }

    public void SetupQuestLayout(bool isPriestTurn, float duration)
    {
        priestQuestLayout.SetActive(isPriestTurn, duration);
        demonQuestLayout.SetActive(!isPriestTurn, duration);
    }
}
