using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class PlayerState_run : SlimeStateBase
{
    [SerializeField] Rigidbody2D rB;
    [SerializeField] float speed;

    public override void FixedLogic()
    {
        base.FixedLogic();
        rB.velocity = new Vector2(Controller._Move.x, Controller._Move.y) * speed * Time.deltaTime;
        Debug.Log("estoy corriendo");
    }

    public override void Logic()
    {
        base.Logic();
        if(Controller._Move == Vector2.zero)
        {
            rB.velocity = Vector2.zero;
            Controller.StateMachine.SwitchState(Controller.StateMachine.Idle);
        }
    }
}
