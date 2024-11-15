using Clases.PA2024.Management;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, Idamageable
{
    [SerializeField] PlayerStateMachine stateMachine;

    public PlayerStateMachine StateMachine => stateMachine;

    public static event HealtDelegate OnHealtChange;

    [SerializeField] int maxHealth;
    int currentHealt;

    Vector2 move;

    bool isAttack;

    public bool IsAttack => isAttack;

    public Vector2 _Move => move;

    public int CurrentHealth
    {
        get => currentHealt;

        set
        {
            currentHealt = value;
            currentHealt = Mathf.Clamp(currentHealt, 0, maxHealth);
            if(currentHealt == 0)
            {
                die();
            }
        }
    }

    public delegate void HealtDelegate(int health, int maxHealth);

    private void OnEnable()
    {
        InputManager.OnMove += Move;
        InputManager.OnAttack += Attack;
    }

    private void OnDisable()
    {
        InputManager.OnMove -= Move;
        InputManager.OnAttack -= Attack;
    }

    private void Awake()
    {
        stateMachine.Initialize(this, stateMachine.Idle);
        currentHealt = maxHealth;
    }

    private void Start()
    {
        CurrentHealth = maxHealth;
    }

    private void Update()
    {
        if(GameManager.CurrentState == GameState.Gameplay)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                GetDamage(20);
            }
        }
    }

    void Attack(bool _value)
    {
        if (GameManager.CurrentState != GameState.Gameplay) return;

        isAttack = _value;

        if (_value)
        {
            stateMachine.SwitchState(stateMachine.Attack);
        }

    }

    void Move(Vector2 input)
    {
        if(GameManager.CurrentState != GameState.Gameplay)return;

        float x = input.x;
        float y = input.y;

        move = new Vector2(x, y);
    }

    public void GetDamage(int damage)
    {
        CurrentHealth -= damage;
        OnHealtChange?.Invoke(currentHealt, maxHealth);
    }

    void die()
    {
        GameManager.SwitchState(GameState.GameOver);
        stateMachine.SwitchState(stateMachine.Death);
    }
}
