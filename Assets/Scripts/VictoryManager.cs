using Clases.PA2024.Management;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryManager : MonoBehaviour
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
        if (state == GameState.Victory)
        {
            UIManager.Instance.SwitchPanel("Victory");
        }
    }
}
