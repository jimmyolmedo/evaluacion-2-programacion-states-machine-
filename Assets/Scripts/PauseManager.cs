using Clases.PA2024.Management;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{

    private void OnEnable()
    {
        InputManager.OnPause += TogglePause;
    }

    private void OnDisable()
    {
        InputManager.OnPause -= TogglePause;
    }

    void TogglePause()
    {
        bool isActive = UIManager.Instance.CurrentIdentifier == "Pause";

        string newPanel = isActive ? "Game Status" : "Pause";

        bool canToggle = false;

        if (UIManager.Instance.CurrentIdentifier == "Game Status") canToggle = true;
        else if (UIManager.Instance.CurrentIdentifier == "Pause") canToggle = true;

        if (!canToggle) return;

        UIManager.Instance.SwitchPanel(newPanel);
    }
}
