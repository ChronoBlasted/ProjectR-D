using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndView : View
{
    [SerializeField] Image bg;
    [SerializeField] TMP_Text title;

    public void UpdateData(bool isPriestWin)
    {
        title.text = isPriestWin ? "PRIEST WIN" : "DEMON WIN";
        bg.color = isPriestWin ? Color.blue : Color.red;
    }
}
