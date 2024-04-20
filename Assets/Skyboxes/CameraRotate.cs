using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    private bool _spinning;
    private GameObject _cam;
    [SerializeField]private float _speed;

    private void Start()
    {
        _cam = Camera.main.gameObject;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            _spinning = !_spinning;
        }

        if (_spinning)
        {
            _cam.transform.Rotate(new Vector3(0,Time.deltaTime * _speed, 0));
        }
    }
}
