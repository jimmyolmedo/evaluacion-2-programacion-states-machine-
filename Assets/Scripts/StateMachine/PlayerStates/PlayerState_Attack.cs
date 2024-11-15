using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class PlayerState_Attack : SlimeStateBase
{
    public override void Logic()
    {
        base.Logic();
        if (Controller.IsAttack)
        {
            Debug.Log("estoy atacando");
        }
        else
        {
            Debug.Log("deje de attacar");
            if(Controller._Move != Vector2.zero)
            {
                Controller.StateMachine.SwitchState(Controller.StateMachine.Run);
            }
            else
            {
                Controller.StateMachine.SwitchState(Controller.StateMachine.Idle);
            }
        }
    }
}
