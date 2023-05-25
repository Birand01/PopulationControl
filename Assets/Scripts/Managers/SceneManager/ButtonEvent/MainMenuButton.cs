using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButton : SceneSwitcher
{
    public delegate void OnMainMenuButtonPressedHandler();
    public static event OnMainMenuButtonPressedHandler OnMainMenuButtonPressed;
    protected override void OnButtonClickedEvent()
    {
        base.OnButtonClickedEvent();
        OnMainMenuButtonPressed?.Invoke();
    }
}
