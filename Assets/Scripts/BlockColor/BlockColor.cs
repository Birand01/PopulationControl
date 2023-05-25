using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockColor : MonoBehaviour
{
    [SerializeField] private List<MeshRenderer> meshRenderers;
    [SerializeField] private Material[] materials;
    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            meshRenderers.AddRange(this.gameObject.GetComponentsInChildren<MeshRenderer>());
        }
    }
    private void Start()
    {
        AssignColor();
    }
    private void AssignColor()
    {
        foreach (MeshRenderer renderer in meshRenderers)
        {
            renderer.material =materials[ Random.Range(0,materials.Length)];
        }
    }
}
