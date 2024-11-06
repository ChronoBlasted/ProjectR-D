using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class QuestLayout : MonoBehaviour
{
    [SerializeField] TMP_Text title;

    public void Init(string questTitle)
    {
        title.text = questTitle;
    }

    public void CompleteQuest()
    {
        title.fontStyle = TMPro.FontStyles.Strikethrough;
    }


    public void UncompleteQuest()
    {
        title.fontStyle = TMPro.FontStyles.Normal;
    }
}
