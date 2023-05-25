using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float limitX;
    [SerializeField] internal float sidewaySpeed;
    private float _finalPos;
    private float _currentPos;

    private void OnEnable()
    {
        PlayerInput.OnPlayerInput += MovePlayer;
    }

    private void MovePlayer()
    {
        if (Input.GetMouseButton(0))
        {
            float percentageX = (Input.mousePosition.x - Screen.width / 2) / (Screen.width * 0.5f) * 2;
            percentageX = Mathf.Clamp(percentageX, -1.0f, 1.0f);
            _finalPos = percentageX * limitX;
        }

        float delta = _finalPos - _currentPos;
        _currentPos += (delta * Time.deltaTime * sidewaySpeed);
        _currentPos = Mathf.Clamp(_currentPos, -limitX, limitX);
        this.transform.localPosition = new Vector3(_currentPos, 0, 0);
    }
    private void OnDisable()
    {
        PlayerInput.OnPlayerInput -= MovePlayer;

    }
}
