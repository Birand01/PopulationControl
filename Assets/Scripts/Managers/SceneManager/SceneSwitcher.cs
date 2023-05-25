using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class SceneSwitcher : MonoBehaviour
{
    protected Button button;
    public delegate void OnButtonClickSoundHandler(string name, bool state);
    public static event OnButtonClickSoundHandler OnButtonClickSound;
    protected virtual void Awake()
    {
        button = GetComponent<Button>();
    }
    private void Start()
    {
        button.onClick.AddListener(OnButtonClickedEvent);
    }
    protected virtual void OnButtonClickedEvent()
    {
        OnButtonClickSound?.Invoke("ButtonClickSound",true);
    }
}
