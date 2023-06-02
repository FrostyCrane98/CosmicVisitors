using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject TitlePanel;
    public GameObject PausePanel;
    public GameObject WinPanel;
    public GameObject GameOverPanel;
    public PlayerHUD PlayerHUD;


    private void OnEnable()
    {
        EventManager.Instance.OnPlayerHit += OnPlayerHit;

    }

    private void OnDisable()
    {
        EventManager.Instance.OnPlayerHit -= OnPlayerHit;
    }
    public void DisablePanels()
    {
        TitlePanel.SetActive(false);
        PausePanel.SetActive(false);
        WinPanel.SetActive(false);
        GameOverPanel.SetActive(false);
    }

    public void EnableTitlePanel()
    {
        DisablePanels();
        TitlePanel.SetActive(true);
    }

    public void EnablePausePanel()
    {
        DisablePanels();
        PausePanel.SetActive(true);
    }

    public void EnableWinPanel()
    {
        DisablePanels();
        WinPanel.SetActive(true);
    }

    public void EnableGameOverPanel()
    {
        DisablePanels();
        GameOverPanel.SetActive(true);
    }

    public void OnPlayerHit(int health)
    {
        PlayerHUD.UpdateHealthBar(health);
    }
}
