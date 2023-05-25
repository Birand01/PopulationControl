using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateInteraction : InteractionBase
{
    public delegate void OnSpawnStickmanHandler(Transform transform,int value);
    public static event OnSpawnStickmanHandler OnSpawnStickman;
    public int populationValue;
    protected override void OnTriggerEnterAction(Collider collider)
    {
        OnSpawnStickman?.Invoke(this.transform, populationValue);
        StartCoroutine(ResetTriggerCoroutine());
    }
    private IEnumerator ResetTriggerCoroutine()
    {
        _collider.isTrigger = false;
        yield return new WaitForSeconds(0.4f);
        _collider.isTrigger = true;
    }
}

