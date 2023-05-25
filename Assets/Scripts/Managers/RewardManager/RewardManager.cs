using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RewardManager : MonoBehaviour
{
    [SerializeField] private TMP_Text coinText;
    [SerializeField] private GameObject coinOfPile;
    [SerializeField] private Vector3[] initialPosition;
    [SerializeField] private Quaternion[] initialRotation;
    [SerializeField] private int numberOfCoins;
    public delegate void OnGameSuccessCanvasActivationHandler(CanvasType type);
    public static event OnGameSuccessCanvasActivationHandler OnGameSuccessCanvasActivation;
    public delegate void OnCoinSoundHandler(string name, bool state);
    public static event OnCoinSoundHandler OnCoinSound;
    private void OnEnable()
    {
        EnemyBase.OnPileOfCoinReward += CoinRewardEvent;
    }
    private void OnDisable()
    {
        EnemyBase.OnPileOfCoinReward -= CoinRewardEvent;

    }
    private void Awake()
    {
        initialPosition = new Vector3[15];
        initialRotation = new Quaternion[15];

        for (int i = 0; i < coinOfPile.transform.childCount; i++)
        {
            initialPosition[i] = coinOfPile.transform.GetChild(i).position;
            initialRotation[i] = coinOfPile.transform.GetChild(i).rotation;
        }
    }
    private void Start()
    {
        coinText.text = PlayerPrefs.GetInt("Coin").ToString();
    }

    private void Reset()
    {
        for (int i = 1; i < coinOfPile.transform.childCount; i++)
        {
            coinOfPile.transform.GetChild(i).position= initialPosition[i];
            coinOfPile.transform.GetChild(i).rotation= initialRotation[i];
        }
    }

    private void CoinRewardEvent()
    {
        RewardPileOfCount(15);
    }

    public void RewardPileOfCount(int amountOfCoin)
    {
        Reset();
        var delay = 0f;
        coinOfPile.SetActive(true);
        for (int i = 0; i < coinOfPile.transform.childCount; i++)
        {
            coinOfPile.transform.GetChild(i).DOScale(1, 0.3f).SetDelay(delay).SetEase(Ease.OutBack);

            coinOfPile.transform.GetChild(i).GetComponent<RectTransform>().
                DOAnchorPos(new Vector2(310, 900), 1f).SetDelay(delay +.5f).SetEase(Ease.InBack);

            coinOfPile.transform.GetChild(i).DORotate(Vector3.zero, 0.5f).SetDelay(delay + 0.5f);
            coinOfPile.transform.GetChild(i).DOScale(0f, 0.3f).SetDelay(delay+2f).SetEase(Ease.OutBack).OnComplete(GameSuccessCanvasActivationHandler);
            delay += 0.1f;
        }
        StartCoroutine(CountCoins(numberOfCoins));
    }

    private void GameSuccessCanvasActivationHandler()
    {
        OnGameSuccessCanvasActivation?.Invoke(CanvasType.GameSuccessScreen);
    }
    private IEnumerator CountCoins(int totalCoin)
    {
        yield return new WaitForSeconds(1f);
        float timer = 0f;
        for (int i = 0; i < totalCoin; i++)
        {
            OnCoinSound?.Invoke("CoinSound", true);
            PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 1);
            coinText.text = PlayerPrefs.GetInt("Coin").ToString();
            timer += 0.001f;
            yield return new WaitForSeconds(timer);
        }
    }
}
