using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private float _sensitivityY; // --> moves camera vertically
    [SerializeField] private float _sensitivityX; // --> moves camera and player horizontally

    //rotation of the player is stored here
    private float xRotation;
    private float yRotation;

    [SerializeField] private Transform _playerOrientation;
    [SerializeField] private Transform _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * _sensitivityX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * _sensitivityY;

        xRotation -= mouseY;
        yRotation += mouseX;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        MoveCamera();
        _playerOrientation.rotation = Quaternion.Euler(xRotation, yRotation, 0);
    }

    private void MoveCamera()
    {
        //you can make this more complex (fov based on speed, shake, etc.)
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
    }
}
