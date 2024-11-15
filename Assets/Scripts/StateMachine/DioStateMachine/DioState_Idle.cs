using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DioState_Idle : DioStateBase
{
    [SerializeField] float Time;
    bool isActive;

    public override void Enter()
    {
        base.Enter();
        isActive = false;
    }

    public override void Logic()
    {
        base.Logic();

        if (GameManager.CurrentState == GameState.Gameplay && !isActive )
        {
            Controller.StartCoroutine(idleDuration());
            isActive = true;
        }
    }

    IEnumerator idleDuration()
    {
        yield return new WaitForSeconds(Time);

        int index = Random.Range(0, 2);

        if(index == 0)
        {
            Controller.StateMachine.SwitchState(Controller.StateMachine.Spawn);
        }
        else
        {
            Controller.StateMachine.SwitchState(Controller.StateMachine.Attack);
        }
    }
}
