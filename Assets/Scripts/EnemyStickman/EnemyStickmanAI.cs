using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class EnemyStickmanAI : StickmanBase
{
    [SerializeField] private EnemyStickmanSO enemyStickmanSO;
    private Transform targets;
    protected override void OnEnable()
    {
        base.OnEnable();
        EnemyBase.OnGameSuccess += StopStickman;
        GameFailLineInteraction.OnGameFail += StopStickman;
    }
    protected override void Awake()
    {
        targets = GameObject.FindGameObjectWithTag("Targets").transform;
        enemyStickmanSO.SetUpStickman(this);
        base.Awake();
    }
    private void Start()
    {
        
        transform.rotation = Quaternion.Euler(0, 180f, 0);
        for (int i = 0; i < targets.childCount; i++)
        {
            //Debug.Log("TARGET location is " + targets.GetChild(Random.Range(0, i)));
            agent.SetDestination(targets.GetChild(Random.Range(0, i)).position);

        }
    }
  
    

   
    protected override void SetDestination()
    {
        agent.SetDestination(targets.position);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        EnemyBase.OnGameSuccess -= StopStickman;
        GameFailLineInteraction.OnGameFail -= StopStickman;

    }
}