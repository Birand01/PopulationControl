using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class SlidingGate : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform gatePrefab;
    [SerializeField] private Transform[] edges;

    [Header("Speed Values")]
    [SerializeField] private float delayTime;
    [SerializeField] private float movementSpeed;
    private int currentEdge;
    private void Awake()
    {
        int randEdge = Random.Range(0, edges.Length);
        gatePrefab.transform.position = edges[randEdge].position;
        currentEdge = System.Convert.ToInt32(!System.Convert.ToBoolean(randEdge));
        MoveToEdge();
    }
    private void MoveToEdge()
    {
        gatePrefab.DOMove(edges[currentEdge].position, 1 / movementSpeed).SetDelay(delayTime).SetEase(Ease.Linear)
        .OnComplete(() =>
        {
            ChangeDestination();
            MoveToEdge();
        });
    }
    private void ChangeDestination()
    {
        bool edgeBool = System.Convert.ToBoolean(currentEdge);
        currentEdge = System.Convert.ToInt32(!edgeBool);
    }
}
