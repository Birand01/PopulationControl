using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BoostStickmanBar : MonoBehaviour
{
    public delegate void OnBossStickManSpawnHandler();
    public static event OnBossStickManSpawnHandler OnBossStickManSpawn;


    [SerializeField] public Slider boostBarSlider;
    [SerializeField] protected Image boostBarFillImage;
    [SerializeField] protected Color maxBoostColor, minBoostColor;
    private float totalBoostAmount;
    internal float boostValue;

    private void OnEnable()
    {
        PlayerInput.OnPlayerBoostRelease += InitializeBoostAmount;
        PlayerStickmanSpawner.OnPlayerStickmanBoost += IncreaseBoostAmount;
    }
    private void OnDisable()
    {
        PlayerInput.OnPlayerBoostRelease -= InitializeBoostAmount;
        PlayerStickmanSpawner.OnPlayerStickmanBoost -= IncreaseBoostAmount;
    }
    private void SetBoostBarUI()
    {
        float boostPercentage = CalculateHealthPercentage();
        boostBarSlider.value = boostPercentage;
        boostBarFillImage.color = Color.Lerp(minBoostColor, maxBoostColor, boostPercentage / boostBarSlider.maxValue);
    }

    private void IncreaseBoostAmount()
    {
        totalBoostAmount += boostValue;
        if(totalBoostAmount==boostBarSlider.maxValue)
        {
            OnBossStickManSpawn?.Invoke();
            totalBoostAmount = 0f;
        }
        SetBoostBarUI();
        totalBoostAmount = Mathf.Clamp(totalBoostAmount, 0f, boostBarSlider.maxValue);

    }
    private void InitializeBoostAmount()
    {
        totalBoostAmount = 0f;
        SetBoostBarUI();
    }

    private float CalculateHealthPercentage()
    {
        return (totalBoostAmount / boostBarSlider.maxValue) * boostBarSlider.maxValue;
    }

}
