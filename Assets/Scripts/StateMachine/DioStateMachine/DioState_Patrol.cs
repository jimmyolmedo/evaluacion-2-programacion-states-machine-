using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DioState_Patrol : DioStateBase
{
    [SerializeField] Vector3 destination;
    [SerializeField] float speed;
    public override void Enter()
    {
        base.Enter();
        float x = Random.Range(-10f, 10f);
        float y = Random.Range(-6f, 6f);

        destination = new Vector2(x, y);
    }

    public override void Logic()
    {
        base.Logic();
        Controller.transform.position = Vector3.MoveTowards(Controller.transform.position, destination, speed * Time.deltaTime);

        if(Controller.transform.position == destination)
        {
            Controller.StateMachine.SwitchState(Controller.StateMachine.Idle);
        }
        
    }
}
