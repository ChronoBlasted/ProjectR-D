using BaseTemplate.Behaviours;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleManager : MonoSingleton<RoleManager>
{
    [SerializeField] float transformationTime = 5f;
    [SerializeField] int turnTime = 120;
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
        PlayerManager.Instance.PlayerMovement.MoveCameraRandomly(transformationTime);
        CameraManager.Instance.ShakeCamera(.25f, transformationTime);

        if (isPriestTurn)
        {
            PostProcessManager.Instance.SetToPriest(transformationTime);
        }
        else
        {
            PostProcessManager.Instance.SetToDemon(transformationTime);
        }

        StartCoroutine(PostProcessManager.Instance.DoTransformationEffect(transformationTime));
        StartCoroutine(EndSetupRoleCor());
    }

    IEnumerator EndSetupRoleCor()
    {
        yield return new WaitForSeconds(transformationTime);

        PlayerManager.Instance.PlayerMovement.StopMoveRandomly();

        if (isPriestTurn)
        {
            PlayerManager.Instance.PlayerRole.SetToPriest();
        }
        else
        {
            PlayerManager.Instance.PlayerRole.SetToDemon();
        }


        StartCoroutine(UIManager.Instance.GameView.UpdateTimer(turnTime));
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
