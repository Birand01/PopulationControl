using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyPool))]
public class EnemyStickmanSpawner : MonoBehaviour
{
    
    [SerializeField] private GameObject enemyPrefab,completeBlock;
    [SerializeField] private Transform spawnPosition;
    [SerializeField][Range(0, 100)] private int minSpawnNumber, maxSpawnNumber;  
    [SerializeField] private int totalEnemyPoolNumber;
    [SerializeField] private float spawnDelay;
    private int randomSpawnNumber;
    private bool isSpawning;
    private EnemyPool enemyPool;
    private void OnEnable()
    {
        EnemyBase.OnGameSuccess += SpawnCheck;
        GameFailLineInteraction.OnGameFail += SpawnCheck;
    }
    private void OnValidate()
    {
        if(minSpawnNumber>maxSpawnNumber)
        {
            minSpawnNumber= maxSpawnNumber;
        }
    }
    private void Awake()
    {
        enemyPool = GetComponent<EnemyPool>();  
        isSpawning = true;
    }
    private void Start()
    {
      
        enemyPool.Initialize(enemyPrefab, totalEnemyPoolNumber);
        StartCoroutine(SpawnEnemyStickman());
    }
   
    private IEnumerator SpawnEnemyStickman()
    {
     
        while (isSpawning)
        {
            randomSpawnNumber = Random.Range(minSpawnNumber, maxSpawnNumber);
            //Debug.Log("Total spawn number is " + randomSpawnNumber);
            for (int i = 0; i < randomSpawnNumber; i++)
            {
                GameObject enemyStickman = enemyPool.CreateObject();
                enemyStickman.GetComponentInChildren<SkinnedMeshRenderer>().material=completeBlock.GetComponent<MeshRenderer>().material;
                enemyStickman.transform.position = spawnPosition.position;
                enemyStickman.transform.rotation = Quaternion.identity;
            }
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    private void SpawnCheck(bool state)
    {
       if(state)
        {
            //StopCoroutine(SpawnEnemyStickman());
            isSpawning = false;
        }
       else
        {
            isSpawning = true;
        }
    }
   
    private void OnDisable()
    {
        GameFailLineInteraction.OnGameFail -= SpawnCheck;
        EnemyBase.OnGameSuccess -= SpawnCheck;

    }
}
