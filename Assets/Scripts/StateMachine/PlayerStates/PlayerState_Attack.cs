using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class PlayerState_Attack : SlimeStateBase
{
    [SerializeField] ParticleSystem particle;
    [SerializeField] GameObject Bullet;
    [SerializeField] Transform aim;

    public override void Logic()
    {
        base.Logic();
        if (Controller.IsAttack)
        {
            particle.gameObject.SetActive(true);
            Debug.Log("estoy atacando");
        }
        else
        {
            particle.gameObject.SetActive(false);
            GameObject instance = GameObject.Instantiate(Bullet, aim.position, Quaternion.identity);
            if(instance.TryGetComponent(out Bullet bullet))
            {
                bullet.impulseBullet(Input.mousePosition - Controller.transform.position);
            }
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
