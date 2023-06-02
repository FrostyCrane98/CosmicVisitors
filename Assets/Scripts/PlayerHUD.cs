using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    private Slider healthBar;

    private void Start()
    {
        healthBar = GetComponentInChildren<Slider>();
    }

    public void UpdateHealthBar(int _health)
    {
        healthBar.value  = _health;
    }

    public void ResetHealthBar()
    {
     healthBar.value = healthBar.maxValue;
    }
}
