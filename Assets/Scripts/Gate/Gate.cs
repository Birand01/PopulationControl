using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum OperationType
{
    //addition,
    //difference,
    multiplication,
    destroy
    //division
}
public class Gate : MonoBehaviour
{
    [Header("Operation")]
    [SerializeField] private OperationType gateOperation;
    public int value;

    [Header("References")]
    [SerializeField] private TextMeshPro operationText;
    [SerializeField] private MeshRenderer forceField;
    [SerializeField] private Material[] operationTypeMaterial;



    private void Awake()
    {
        AssignOperation();
    }

    private void AssignOperation()
    {
        string finalText = "";

        //if (gateOperation == OperationType.addition)
        //    finalText += "+";
        //if (gateOperation == OperationType.difference)
        //    finalText += "-";
        if (gateOperation == OperationType.multiplication)
        {
            finalText += "x";
            finalText += value.ToString();
            operationText.text = finalText;
        }
           
        if (gateOperation == OperationType.destroy)
        {
            finalText = "";
            operationText.text = finalText.ToString();
        }
        //if (gateOperation == OperationType.division)
        //    finalText += "÷";

       

        if (/*gateOperation == OperationType.addition ||*/ gateOperation == OperationType.multiplication)
        {
            forceField.material = operationTypeMaterial[0];
        }
        else
        {
            forceField.material = operationTypeMaterial[1];
        }

    }

}
