using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    // Al heredar StateMachine con los genericos creados anteriormente llamados
    //  SlimeStateBase, el cual hereda de StateBase y
    //  SlimeController, el cual seria el controlador con las referencias principales de nuestro objeto,
    // podremos utilizar nuestro SlimeStateMachine para transicionar, guardar e inicializar correctamente
    // los distintos estados de nuestro objeto.

    // Anteriormente utilizabamos un State Factory que se encargaba de eso, pero para facilitar un poco
    // y no tener que crear varios scripts, podemos utilizar el StateMachine para guardar nuestros estados sin 
    // ningun problema.
    public class PlayerStateMachine : StateMachine<SlimeStateBase, Player>
    {
        // Variables
        [Header("States")]
        [SerializeField] private PlayerState_Idle idle;
        [SerializeField] private PlayerState_Attack attack;
        [SerializeField] private PlayerState_run run;
        [SerializeField] private PlayerState_Death death;

        // Properties
        public PlayerState_Idle Idle => idle;
        public PlayerState_Attack Attack => attack;
        public PlayerState_run Run => run;
        public PlayerState_Death Death => death;

        // Methods
        protected override void InitializeStates(Player controller)
        {
            idle.Initialize(controller);
            attack.Initialize(controller);
            run.Initialize(controller);
            death.Initialize(controller);
        }
    }
