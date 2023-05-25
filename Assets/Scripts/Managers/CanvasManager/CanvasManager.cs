using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum CanvasType
{
    GameUI,
    GameFailScreen,
    GameSuccessScreen
}
public class CanvasManager : MonoBehaviour
{
    List<CanvasController> canvasControllerList;
    CanvasController lastActiveCanvas;
    private void OnEnable()
    {
        RewardManager.OnGameSuccessCanvasActivation += SwitchCanvas;
        GameFailLineInteraction.OnGameFailCanvasActivation += SwitchCanvas;   
    }
    private void Awake()
    {
        canvasControllerList=GetComponentsInChildren<CanvasController>().ToList();
        canvasControllerList.ForEach(x=>x.gameObject.SetActive(false));
        SwitchCanvas(CanvasType.GameUI);
    }

    


    private void SwitchCanvas(CanvasType canvasType)
    {
        if(lastActiveCanvas!=null)
        {
            lastActiveCanvas.gameObject.SetActive(false);
        }
        CanvasController desiredCanvas=canvasControllerList.Find(x=>x.canvasType == canvasType);
        if(desiredCanvas!=null)
        {
            desiredCanvas.gameObject.SetActive(true);
            lastActiveCanvas = desiredCanvas;
        }
        else
        {
            Debug.LogWarning("The desired canvas was not found");
        }
    }

    private void OnDisable()
    {
        RewardManager.OnGameSuccessCanvasActivation -= SwitchCanvas;
        GameFailLineInteraction.OnGameFailCanvasActivation -= SwitchCanvas;
    }
}
