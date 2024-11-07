using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class QuestLayout : MonoBehaviour
{
    [SerializeField] TMP_Text title;

    public void SetText(string questTitle, int amount)
    {
        title.text = questTitle;

        if (amount <= 0) CompleteQuest();
        else UncompleteQuest();
    }

    void CompleteQuest()
    {
        title.fontStyle = TMPro.FontStyles.Strikethrough;
    }


    void UncompleteQuest()
    {
        title.fontStyle = TMPro.FontStyles.Normal;
    }
}
