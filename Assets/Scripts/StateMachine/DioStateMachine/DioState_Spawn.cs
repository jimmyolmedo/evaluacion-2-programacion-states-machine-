using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DioState_Spawn : DioStateBase
{
    [SerializeField] GameObject obj;
    [SerializeField] List<Transform> positions;

    public override void Enter()
    {
        base.Enter();
        Controller.StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        int index = Random.Range(0, 4);

        while(index > 0)
        {
            int positionIndex = Random.Range(0, positions.Count);
            GameObject instance = GameObject.Instantiate(obj, positions[positionIndex].position, Quaternion.identity);
            index--;
            yield return new WaitForSeconds(.5f);
        }

        Controller.StateMachine.SwitchState(Controller.StateMachine.Patrol);
    }
}
