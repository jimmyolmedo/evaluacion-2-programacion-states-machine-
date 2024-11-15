using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dio : MonoBehaviour, Idamageable
{
    [SerializeField] DioStateMachine stateMachine;

    public DioStateMachine StateMachine => stateMachine;

    [SerializeField] int maxHealth;

    int currenHealth;

    public int CurrenHealth
    {
        get => currenHealth;

        set
        {
            currenHealth = value;
            currenHealth = Mathf.Clamp(currenHealth, 0, maxHealth);
            if (currenHealth == 0)
            {
                die();
            }
        }
    }

    private void Awake()
    {
        stateMachine.Initialize(this, stateMachine.Idle);
        currenHealth = maxHealth;
    }

    private void die()
    {
        stateMachine.SwitchState(stateMachine.Death);
    }

    public void GetDamage(int damage)
    {
        CurrenHealth -= damage;
    }

}
