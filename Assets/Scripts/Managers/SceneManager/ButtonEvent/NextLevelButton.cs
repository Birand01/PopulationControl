using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelButton : SceneSwitcher
{
    public delegate void OnNextLevelButtonPressedHandler();
    public static event OnNextLevelButtonPressedHandler OnNextLevelSwitch;
    protected override void OnButtonClickedEvent()
    {
        base.OnButtonClickedEvent();
        OnNextLevelSwitch?.Invoke();
    }

}
