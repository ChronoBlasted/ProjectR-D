using BaseTemplate.Behaviours;
using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
    [field: SerializeField] public Canvas MainCanvas { get; protected set; }

    [field: SerializeField] public GameView GameView { get; protected set; }
    [field: SerializeField] public EndView EndGameView { get; protected set; }
    [field: SerializeField] public MenuView MenuView { get; protected set; }
    [field: SerializeField] public LoadingView LoadingView { get; protected set; }


    [Header("Black Shade Ref")]
    [SerializeField] Button _blackShadeButton;
    [SerializeField] Image _blackShadeImg;

    View _currentView;

    Tweener _blackShadeTweener;

    public void Init()
    {
        GameManager.Instance.OnGameStateChanged += HandleStateChange;

        InitView();
    }

    public void InitView()
    {
        MenuView.Init();
        GameView.Init();
        EndGameView.Init();
        LoadingView.Init();

        HideBlackShade();
    }

    #region View

    public void ChangeView(View newPanel, bool _instant = false)
    {
        if (newPanel == _currentView) return;

        if (_currentView != null)
        {
            newPanel.CloseView();
        }

        _currentView = newPanel;

        _currentView.gameObject.SetActive(true);

        _currentView.OpenView(_instant);

    }

    public void ChangeView(View newPanel)
    {
        ChangeView(newPanel, false);
    }

    #endregion

    #region GameState

    void HandleStateChange(GameState newState)
    {
        switch (newState)
        {
            case GameState.Menu:
                HandleMenu();
                break;
            case GameState.Game:
                HandleGame();
                break;
            case GameState.End:
                HandleEnd();
                break;
            default:
                break;
        }
    }

    void HandleMenu()
    {
        ChangeView(MenuView, true);
    }
    void HandleGame()
    {
        ChangeView(GameView);
    }
    void HandleEnd()
    {
        ChangeView(EndGameView);
    }

    #endregion

    public void ShowBlackShade(UnityAction _onClickAction)
    {
        if (_blackShadeTweener.IsActive()) _blackShadeTweener.Kill();

        _blackShadeTweener = _blackShadeImg.DOFade(.8f, .1f);

        _blackShadeImg.raycastTarget = true;

        _blackShadeButton.onClick.AddListener(_onClickAction);
    }

    public void HideBlackShade(bool _instant = true)
    {
        if (_blackShadeTweener.IsActive()) _blackShadeTweener.Kill();

        if (_instant) _blackShadeTweener = _blackShadeImg.DOFade(0f, 0);
        else _blackShadeTweener = _blackShadeImg.DOFade(0f, .1f);

        _blackShadeImg.raycastTarget = false;

        _blackShadeButton.onClick.RemoveAllListeners();
    }

    public static string GetFormattedInt(float amount)
    {
        return amount.ToString("#,0");
    }
}
