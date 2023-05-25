using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public delegate void OnPlayerInputHandler();
    public static event OnPlayerInputHandler OnPlayerInput;
    public delegate void OnStickmanSpawnHandler(bool state);
    public static event OnStickmanSpawnHandler OnStickmanSpawn;

    public delegate void OnPlayerBoostReleaseHandler();
    public static event OnPlayerBoostReleaseHandler OnPlayerBoostRelease;

    private bool isLevelEnd;

    private void OnEnable()
    {
        EnemyBase.OnGameSuccess += LevelEndHandler;
        GameFailLineInteraction.OnGameFail += LevelEndHandler;
    }
    private void OnDisable()
    {
        EnemyBase.OnGameSuccess -= LevelEndHandler;
        GameFailLineInteraction.OnGameFail -= LevelEndHandler;

    }
    private void Update()
    {
        OnPlayerMovement();
        OnStickManSpawn();
       
    }


    private void LevelEndHandler(bool state)
    {
        isLevelEnd = state;
    }

    private void OnPlayerMovement()
    {
        if(Input.GetMouseButton(0) && !isLevelEnd)
        {
            OnPlayerInput?.Invoke();
            OnStickmanSpawn?.Invoke(!isLevelEnd);
        }
    }
   

    private void OnStickManSpawn()
    {
        if (Input.GetMouseButtonUp(0))
        {
            OnPlayerBoostRelease?.Invoke();
            OnStickmanSpawn?.Invoke(false);
        }
    }
}
