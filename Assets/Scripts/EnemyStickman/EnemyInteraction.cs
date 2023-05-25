using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteraction : MonoBehaviour
{
    public delegate void OnCollisionParticleHandler(int index, Vector3 position);
    public static event OnCollisionParticleHandler OnCollisionParticle;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Stickman"))
        {
            OnCollisionParticle?.Invoke(2, this.transform.position);
            this.gameObject.SetActive(false);
            other.gameObject.SetActive(false);
        }
    }
   
   
}
