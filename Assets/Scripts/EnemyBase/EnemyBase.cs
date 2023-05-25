using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [Header("Size & Color")]
    public int startingSize;
    [SerializeField] private Material[] blockColor;
    [SerializeField] private MeshRenderer blockMesh;
    [Header("References")]
    [SerializeField] private GameObject completeBlock;
    [SerializeField] private GameObject brokenBlock;
    [SerializeField] private TextMeshPro blockSizeText;

    //-------------- DELEGATES -------------
    public delegate void OnGameSuccessHandler(bool state);
    public delegate void OnEnemyGateDestroySoundHandler(string name, bool state);
    public delegate void OnPileOfCoinRewardHandler();
    public delegate void OnGameSuccessParticleHandler(int index, Vector3 position);
    //---------------------------------

    //----------- EVENTS ---------------
    public static event OnGameSuccessHandler OnGameSuccess;
    public static event OnEnemyGateDestroySoundHandler OnEnemyGateDestroySound;
    public static event OnPileOfCoinRewardHandler OnPileOfCoinReward;
    public static event OnGameSuccessParticleHandler OnGameSuccessParticle;
    //-------------------------------------


    public static EnemyBase Instance { get; private set; }
    private void OnEnable()
    {
        EnemyBaseInteraction.OnEnemySizeTextDecrease += CheckHit;
    }
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
       
        completeBlock.SetActive(true);
        brokenBlock.SetActive(false);
        blockSizeText.text = startingSize.ToString();
        AssignColor();
    }
    private void AssignColor()
    {
        int colorIndex = (startingSize - 1) / 7;
        colorIndex = Mathf.Clamp(colorIndex, 0, blockColor.Length);
        blockMesh.material = blockColor[colorIndex];
    }

    private void CheckHit()
    {
        blockSizeText.text = startingSize.ToString();
        startingSize--;
        if(startingSize <= 0 )
        {
            GameSuccessEvent();
        }
       
    }
    private void GameSuccessEvent()
    {
        OnEnemyGateDestroySound?.Invoke("EnemyBaseDestroySound", true);
        OnPileOfCoinReward?.Invoke();
        OnGameSuccess?.Invoke(true);
        OnGameSuccessParticle?.Invoke(0, this.transform.position);   
        completeBlock.SetActive(false);
        brokenBlock.SetActive(true);
        blockSizeText.gameObject.SetActive(false);
    }
  
    private void OnDisable()
    {
        EnemyBaseInteraction.OnEnemySizeTextDecrease -= CheckHit;
    }
}
