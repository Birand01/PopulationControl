using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BossInteraction : MonoBehaviour
{
    [SerializeField] private int touchCount;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("EnemyStickman"))
        {
            touchCount++;
            Debug.Log("Touch count is" + touchCount);
            this.transform.DOScale(this.transform.localScale / touchCount, 0.5f);
            other.gameObject.SetActive(false);
            if (touchCount == 3)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
   
    
   
}
