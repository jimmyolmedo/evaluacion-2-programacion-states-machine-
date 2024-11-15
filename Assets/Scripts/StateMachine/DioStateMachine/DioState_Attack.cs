using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DioState_Attack : DioStateBase
{
    [SerializeField] GameObject bullet;

    public override void Enter()
    {
        base.Enter();
        Debug.Log("atacado");
        Controller.StateMachine.SwitchState(Controller.StateMachine.Patrol);
    }
}
