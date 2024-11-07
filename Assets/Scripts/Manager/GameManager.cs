using BaseTemplate.Behaviours;
using DG.Tweening;
using System;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public enum GameState { Menu, Game, End }

public class GameManager : MonoSingleton<GameManager>
{
    public event Action<GameState> OnGameStateChanged;
    GameState _gameState;

    public GameState GameState { get => _gameState; }

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        PostProcessManager.Instance.Init();

        CameraManager.Instance.Init();

        SpawnerManager.Instance.Init();

        PlayerManager.Instance.Init();

        QuestManager.Instance.Init();

        RoleManager.Instance.Init();

        UIManager.Instance.Init();

        UpdateStateToGame();
    }
    public void UpdateGameState(GameState newState)
    {
        _gameState = newState;

        // Debug.Log("New GameState : " + _gameState);

        switch (_gameState)
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

        OnGameStateChanged?.Invoke(_gameState);
    }

    void HandleMenu()
    {
    }

    void HandleGame()
    {
    }

    void HandleEnd()
    {
    }

    private void Update()
    {
        if (Keyboard.current.rKey.isPressed) ReloadScene();
    }


    public void UpdateStateToMenu() => UpdateGameState(GameState.Menu);
    public void UpdateStateToGame() => UpdateGameState(GameState.Game);
    public void UpdateStateToEnd() => UpdateGameState(GameState.End);

    public void ReloadScene()
    {
        DOTween.KillAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitApp() => Application.Quit();
}