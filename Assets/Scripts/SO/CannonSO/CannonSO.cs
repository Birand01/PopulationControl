using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CannonConfiguration", menuName = "ScriptableObjects/CannonConfiguration", order = 2)]
public class CannonSO : ScriptableObject
{
    public float boostValue;
    public float maxBoostAmount;
    public float spawnDelay;
    public int numberOfStickmanToSpawn;
    public void SetUpCannon(CannonConfiguration cannonConfiguration)
    {
        cannonConfiguration.GetComponent<BoostStickmanBar>().boostValue = boostValue;
        cannonConfiguration.GetComponent<BoostStickmanBar>().boostBarSlider.maxValue = maxBoostAmount;
        cannonConfiguration.GetComponentInChildren<PlayerStickmanSpawner>().spawnDelay= spawnDelay;
        cannonConfiguration.GetComponentInChildren<PlayerStickmanSpawner>().numberOfStickManToSpawn = numberOfStickmanToSpawn;
    }
}
