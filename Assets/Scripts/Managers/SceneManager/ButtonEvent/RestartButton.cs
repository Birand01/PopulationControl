using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : SceneSwitcher
{
    public delegate void OnRestartLevelButtonPressedHandler();
    public static event OnRestartLevelButtonPressedHandler OnRestartLevelButtonPressed;
    protected override void OnButtonClickedEvent()
    {
        base.OnButtonClickedEvent();
        OnRestartLevelButtonPressed?.Invoke();
    }

   
}
