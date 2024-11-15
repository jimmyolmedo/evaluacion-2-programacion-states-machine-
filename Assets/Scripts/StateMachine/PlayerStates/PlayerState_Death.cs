using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [System.Serializable]
    public class PlayerState_Death : SlimeStateBase
    {
        // Variables
        [SerializeField] private float time;
        [SerializeField] private AnimationCurve curve;

        // Methods
        public override void Enter()
        {
            base.Enter();
            Debug.Log("se me murio el player");
        }
    }