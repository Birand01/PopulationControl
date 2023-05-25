using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonConfiguration : MonoBehaviour
{
    [SerializeField] private CannonSO cannonSO;

    private void OnEnable()
    {
        cannonSO.SetUpCannon(this);
    }
}
