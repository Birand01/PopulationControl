using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerStickmanAI : StickmanBase
{
    [SerializeField] private PlayerStickmanSO playerStickmanSO;


    protected override void OnEnable()
    {
        base.OnEnable();
        EnemyBase.OnGameSuccess += StopStickman;
        GameFailLineInteraction.OnGameFail += StopStickman;
    }

    protected override void Awake()
    {    
       
        playerStickmanSO.SetUpStickman(this);
        base.Awake();
    }

   

    protected override void OnDisable()
    {
        base.OnDisable();
        EnemyBase.OnGameSuccess -= StopStickman;
        GameFailLineInteraction.OnGameFail -= StopStickman;
    }

    protected override void SetDestination()
    {
        agent.SetDestination(target.position);
    }
}
