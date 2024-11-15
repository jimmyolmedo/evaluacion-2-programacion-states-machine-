using Clases.PA2024.Management;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    private void OnEnable()
    {
        GameManager.OnStateChange += OnStateChange;
    }

    private void OnDisable()
    {
        GameManager.OnStateChange -= OnStateChange;
    }

    private void OnStateChange(GameState state)
    {
        if (state == GameState.GameOver)
        {
            UIManager.Instance.SwitchPanel("Game Over");
        }
    }
}
