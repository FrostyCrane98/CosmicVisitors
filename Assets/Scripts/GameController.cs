using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    public EnemyController EnemyController;
    public UIController UIController;
    public AudioPlayer AudioPlayer;
    public PlayerManager PlayerManager;
    public BulletManager BulletManager;
    public Background Background;

    public InputAction PauseAction;

    public AudioClip TitleOst;
    public AudioClip WinOst;
    public AudioClip GameOverOst;
    public AudioClip InGameOst;
    private enum eGameState
    {
        TitleScreen,
        Start,
        Idle,
        Resume,
        Pause,
        Win,
        GameOver
    }    

    private eGameState State;

    private void OnEnable()
    {
        PauseAction.Enable();
        PauseAction.started += TogglePause;
        EventManager.Instance.OnPlayerDeath += OnPlayerDeath;
        EventManager.Instance.OnStageClear += OnStageClear;
    }

    private void OnDisable()
    {
        PauseAction.Disable();
        PauseAction.started -= TogglePause;
        EventManager.Instance.OnPlayerDeath -= OnPlayerDeath;
        EventManager.Instance.OnStageClear -= OnStageClear;
    }

    private void Start()
    {
        AudioPlayer.Play(TitleOst);
        State = eGameState.TitleScreen;
    }
    private void Update()
    {
        switch (State)
        {
            case eGameState.TitleScreen:
                Time.timeScale = 0;
                UIController.DisablePanels();
                UIController.EnableTitlePanel();
                break;
        
            case eGameState.Start:
                BulletManager.ClearBullets();
                EnemyController.ResetEnemies();
                PlayerManager.SpawnNewPlayer();
                UIController.PlayerHUD.ResetHealthBar();
                UIController.DisablePanels();
                Time.timeScale = 1;
                Background.isPlaying = true;
                SetIdleState();
                break;

            case eGameState.Pause:
                Time.timeScale = 0;
                Background.isPlaying = false;
                UIController.DisablePanels();
                UIController.EnablePausePanel();
                break;

            case eGameState.Resume:
                Time.timeScale = 1;
                Background.isPlaying = true;
                UIController.DisablePanels();
                SetIdleState();
                break;

            case eGameState.Win:
                Time.timeScale = 0;
                Background.isPlaying = false;
                UIController.EnableWinPanel();
                break;

            case eGameState.GameOver:
                Time.timeScale = 0;
                Background.isPlaying = false;
                UIController.EnableGameOverPanel();
                break;
        
            case eGameState.Idle:             
                break;
        }
    }



    public void ExitGame()
    {
        Application.Quit();        
    }

    public void StartGame()
    {
        State = eGameState.Start;        
    }

    public void Resume()
    {
        State = eGameState.Resume;
    }

    private void TogglePause(InputAction.CallbackContext context)
    {
        if (State == eGameState.Idle)
        {
            AudioPlayer.Pause();
            State = eGameState.Pause;
        }
        else if (State == eGameState.Pause)
        {
            AudioPlayer.Resume();
            State = eGameState.Resume;
        }
    }

    public void QuitPlay()
    {
        AudioPlayer.ToggleLoop(true);
        AudioPlayer.Play(TitleOst);
        State = eGameState.TitleScreen;
    }

    private void SetIdleState()
    {
        AudioPlayer.Play(InGameOst);
        State = eGameState.Idle;
    }

    private void OnPlayerDeath()
    {
        AudioPlayer.ToggleLoop(false);
        AudioPlayer.Play(GameOverOst);
        State = eGameState.GameOver;
    }

    private void OnStageClear()
    {
        AudioPlayer.ToggleLoop(false);
        AudioPlayer.Play(WinOst);
        State = eGameState.Win;
    }

}
