using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseInteraction : InteractionBase
{
    public delegate void OnEnemySizeTextDecreaseHandler();
    public static event OnEnemySizeTextDecreaseHandler OnEnemySizeTextDecrease;
    protected override void OnTriggerEnterAction(Collider collider)
    {
        OnEnemySizeTextDecrease?.Invoke();
       collider.gameObject.SetActive(false);
    }
}
