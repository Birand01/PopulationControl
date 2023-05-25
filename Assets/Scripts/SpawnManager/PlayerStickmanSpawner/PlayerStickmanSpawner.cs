using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StickmanPool))]
[RequireComponent (typeof(BossStickmanPool))]
public class PlayerStickmanSpawner : MonoBehaviour
{
    public delegate void OnStickmanSpawnParticleHandler(int index, Vector3 position);
    public static event OnStickmanSpawnParticleHandler OnStickmanSpawnParticle;
    public delegate void OnPlayerStickmanBoostPressHandler();
    public static event OnPlayerStickmanBoostPressHandler OnPlayerStickmanBoost;
    public delegate void OnBossStickManSpawnSoundHandler(string name, bool state);
    public static event OnBossStickManSpawnSoundHandler OnBossStickManSound;


    [SerializeField] protected GameObject stickmanPrefab,bossPrefab;
    [SerializeField] protected List<Transform>  stickmanPosition;
    internal float spawnDelay;
    internal int numberOfStickManToSpawn;
    private Collider[] colliders;
    private StickmanPool stickmanPool;
    private BossStickmanPool bossStickmanPool;
    private bool canSpawn = true;
    private float currentDelay;
    private void OnEnable()
    {
        GateInteraction.OnSpawnStickman += SpawnStickManAtGate;
        PlayerInput.OnStickmanSpawn += SpawnStickManWithInput;
        BoostStickmanBar.OnBossStickManSpawn += SpawnBossStickMan;
    }
    private void Awake()
    {
        bossStickmanPool = GetComponent<BossStickmanPool>();
        colliders = GetComponentsInParent<Collider>();
        stickmanPool = GetComponent<StickmanPool>();
    }
    private void Start()
    {
        stickmanPool.Initialize(stickmanPrefab, numberOfStickManToSpawn);
        bossStickmanPool.Initialize(bossPrefab, numberOfStickManToSpawn);
    }
    private void Update()
    {
        if (canSpawn == false)
        {
            currentDelay -= Time.deltaTime;
            if (currentDelay <= 0)
            {
                canSpawn = true;
            }
        }
    }
    private void SpawnStickManWithInput(bool state)
    {
       
            if (canSpawn && state)
            {
                foreach (var position in stickmanPosition)
                {
                    OnPlayerStickmanBoost?.Invoke();
                    OnStickmanSpawnParticle?.Invoke(1, position.position);
                    canSpawn = false;
                    currentDelay = spawnDelay;
                    GameObject stickman = stickmanPool.CreateObject();
                    stickman.transform.position = position.position;
                    stickman.transform.rotation = position.rotation;
                    foreach (var collider in colliders)
                    {
                        Physics.IgnoreCollision(stickman.GetComponent<Collider>(), collider);
                    }
                }
            }
        else
                return;
       
       
      
    }

    private void SpawnBossStickMan()
    {
        foreach (var position in stickmanPosition)
        {
            OnBossStickManSound?.Invoke("PlayerBossSpawnSound", true);
            OnStickmanSpawnParticle?.Invoke(1, position.position);
            GameObject stickman = bossStickmanPool.CreateObject();
            stickman.transform.position = position.position;
            stickman.transform.rotation = position.rotation;
            foreach (var collider in colliders)
            {
                Physics.IgnoreCollision(stickman.GetComponent<Collider>(), collider);
            }
        }
    }
   

    private void SpawnStickManAtGate(Transform transform,int numberToSpawn)
    {
        for (int i =1; i < numberToSpawn; i++)
        {
            GameObject stickman = stickmanPool.CreateObject();
            stickman.transform.position = transform.position;
            stickman.transform.rotation = Quaternion.identity;
        }

    }
   
    private void OnDisable()
    {
        GateInteraction.OnSpawnStickman -= SpawnStickManAtGate;
        PlayerInput.OnStickmanSpawn -= SpawnStickManWithInput;
        BoostStickmanBar.OnBossStickManSpawn -= SpawnBossStickMan;


    }
}
