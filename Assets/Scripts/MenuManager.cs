using Clases.PA2024.Management;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
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
        if (state == GameState.Menu)
        {
            UIManager.Instance.SwitchPanel("Menu");
        }
    }

    public void DisactiveMenu()
    {
        if(GameManager.CurrentState != GameState.Menu) return;

        GameManager.SwitchState(GameState.Gameplay);
        UIManager.Instance.SwitchPanel("Game Status");
    }
}
