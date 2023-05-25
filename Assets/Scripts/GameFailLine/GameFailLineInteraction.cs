using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFailLineInteraction : InteractionBase
{
    public delegate void OnGameFailEventHandler(bool state);
    public static event OnGameFailEventHandler OnGameFail;
    public delegate void OnGameFailParticleHandler(int index, Vector3 position);
    public static event OnGameFailParticleHandler OnGameFailParticle;
    public delegate void OnGameFailCanvasActivationHandler(CanvasType canvasType);
    public static event OnGameFailCanvasActivationHandler OnGameFailCanvasActivation;


    protected override void OnTriggerEnterAction(Collider collider)
    {
        OnGameFailCanvasActivation?.Invoke(CanvasType.GameFailScreen);
        OnGameFailParticle.Invoke(3, this.transform.position);
        OnGameFail?.Invoke(true);
    }

   
}
