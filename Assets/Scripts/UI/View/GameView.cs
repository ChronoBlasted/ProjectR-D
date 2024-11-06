using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameView : View
{
    [SerializeField] TMP_Text timerTurnTxt;

    public void UpdateQuest()
    {

    }

    public IEnumerator UpdateTimer(int totalSeconds)
    {
        while (totalSeconds >= 0)
        {
            int minutes = totalSeconds / 60;
            int seconds = totalSeconds % 60;

            timerTurnTxt.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            yield return new WaitForSeconds(1f);

            totalSeconds--;
        }

        RoleManager.Instance.ChangeRole();

        timerTurnTxt.text = "00:00";
    }
}
