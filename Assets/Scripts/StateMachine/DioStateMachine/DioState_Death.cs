using Clases.PA2024.Management;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DioState_Death : DioStateBase
{
    public override void Enter()
    {
        base.Enter();
        GameManager.SwitchState(GameState.Victory);
        UIManager.Instance.SwitchPanel("Victory");
        Controller.gameObject.SetActive(false);
    }
}
