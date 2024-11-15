using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerState_Idle : SlimeStateBase
{
    public override void Logic()
    {
        base.Logic();
        if(Controller._Move != Vector2.zero )
        {
            Controller.StateMachine.SwitchState(Controller.StateMachine.Run);
        }


    }
}
