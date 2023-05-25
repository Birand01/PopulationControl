using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class StickmanBase : MonoBehaviour
{
    internal NavMeshAgent agent;
    protected Transform target;
    internal string targetName;

    protected virtual void OnEnable()
    {
        StartCoroutine(UpdatePath());
    }
    protected virtual void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag(targetName).transform;
    }
   
    protected virtual IEnumerator UpdatePath()
    {
        float refreshRate = 0.1f;
        while (target != null)
        {
            SetDestination();
            yield return new WaitForSeconds(refreshRate);
        }


    }

    protected abstract void SetDestination();
    
    protected virtual void StopStickman(bool state)
    {
        if (state)
        {
            agent.isStopped = true;
            this.gameObject.SetActive(false);
        }
        else
            agent.isStopped = false;
    }
    protected virtual void OnDisable()
    {
        StopCoroutine(UpdatePath());
    }
}
