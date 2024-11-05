using BaseTemplate.Behaviours;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleManager : MonoSingleton<RoleManager>
{
    [SerializeField] float transformationTime = 5f;
    bool isPriestTurn;

    public void Init()
    {
        float randomStart = Random.Range(0f, 1f);

        isPriestTurn = randomStart > .5f;

        SetupRole();
        SetupQuest();
    }

    #region Player Role

    void SetupRole()
    {
        CameraManager.Instance.ShakeCamera(4, transformationTime);
        PlayerManager.Instance.PlayerMovement.enabled = false;

        if (isPriestTurn)
        {
            PostProcessManager.Instance.SetToPriest();
        }
        else
        {
            PostProcessManager.Instance.SetToDemon();
        }

        StartCoroutine(EndSetupRoleCor());
    }

    IEnumerator EndSetupRoleCor()
    {
        yield return new WaitForSeconds(transformationTime);

        PlayerManager.Instance.PlayerMovement.enabled = true;
    }

    public void ChangeRole()
    {
        isPriestTurn = !isPriestTurn;

        SetupRole();
    }

    #endregion

    #region Quest

    void SetupQuest()
    {
        UIManager.Instance.GameView.UpdateQuest();
    }

    #endregion
}
