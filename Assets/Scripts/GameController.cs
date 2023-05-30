using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public enum eGameState
    {
        Start,
        Play,
        Resume,
        Pause,
        Win,
        GameOver
    }

    public eGameState State;
    public Player Player;

    public void ExitGame()
    {
        Application.Quit();        
    }

    public void Start()
    {
        State = eGameState.Start;        
    }
}
