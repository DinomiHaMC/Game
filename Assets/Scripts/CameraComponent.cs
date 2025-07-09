using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraComponent : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField]  GameObject _player;
    [SerializeField] private bool _cur = true;

    private float _xRotation;

    private void Update()
    {
        var mouseX = Input.GetAxis("Mouse X") * -_speed * Time.deltaTime;
        var mouseY = Input.GetAxis("Mouse Y") * -_speed * Time.deltaTime;
        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90, 90);
        transform.localRotation = Quaternion.Euler(-_xRotation, 0, 0);
        _player.transform.Rotate(Vector3.up * -mouseX);

        if (_cur)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
