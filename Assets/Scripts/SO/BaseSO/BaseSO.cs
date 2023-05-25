
using UnityEngine;
using UnityEngine.AI;

public abstract class BaseSO : ScriptableObject
{
    public float speed;
    public float angularSpeed;
    public float acceleration;
    public string targetName;

    internal void SetUpStickman(StickmanBase stickmanBase)
    {
        stickmanBase.GetComponent<NavMeshAgent>().speed = speed;
        stickmanBase.GetComponent<NavMeshAgent>().angularSpeed = angularSpeed;
        stickmanBase.GetComponent<NavMeshAgent>().acceleration = acceleration;
        stickmanBase.targetName = targetName;
    }
}
