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
    public class DioStateMachine : StateMachine<DioStateBase, Dio>
    {
        // Variables
        [Header("States")]
        [SerializeField] private DioState_Idle idle;
        [SerializeField] private DioState_Attack attack;
        [SerializeField] private DioState_Patrol patrol;
        [SerializeField] private DioState_Spawn spawn;
        [SerializeField] private DioState_Death death;

        // Properties
        public DioState_Idle Idle => idle;
        public DioState_Attack Attack => attack;
        public DioState_Patrol Patrol => patrol;
        public DioState_Spawn Spawn => spawn;
        public DioState_Death Death => death;

        // Methods
        protected override void InitializeStates(Dio controller)
        {
        idle.Initialize(controller);
        attack.Initialize(controller);
        spawn.Initialize(controller);
        patrol.Initialize(controller);
        death.Initialize(controller);
        }
    }
