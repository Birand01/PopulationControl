using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagement : MonoBehaviour
{
    [SerializeField] private TMP_Text levelText;
    private int sceneIndex=0;

    private void OnEnable()
    {
        RestartButton.OnRestartLevelButtonPressed += LoadCurrentScene;
        NextLevelButton.OnNextLevelSwitch += GoToNextBattleScene;
        MainMenuButton.OnMainMenuButtonPressed += GoToMainMenu;
    }
    private void Start()
    {
        levelText.text="LEVEL " +SceneManager.GetActiveScene().buildIndex.ToString();
        StartCoroutine(DisableLevelText());
    }

    private void GoToMainMenu()
    {
        sceneIndex = 0;
        SceneManager.LoadScene(sceneIndex); 
    }
    private void LoadCurrentScene()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
    }
    private  void GoToNextBattleScene()
    {
        sceneIndex++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + sceneIndex);
        if(sceneIndex==5)
        {
            sceneIndex = 0;
            SceneManager.LoadScene(sceneIndex);
        }
    }

    private IEnumerator DisableLevelText()
    {
        yield return new WaitForSeconds(1f);
        levelText.gameObject.transform.DOScale(0, 0.5f);
    }

    private void OnDisable()
    {
        RestartButton.OnRestartLevelButtonPressed -= LoadCurrentScene;
        MainMenuButton.OnMainMenuButtonPressed -= GoToMainMenu;
        NextLevelButton.OnNextLevelSwitch -= GoToNextBattleScene;
    }
}
