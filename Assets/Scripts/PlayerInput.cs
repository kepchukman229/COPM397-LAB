using System;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.InputSystem;
using KBCore.Refs;
using Unity.Mathematics;

[RequireComponent(typeof(CharacterController))]

public class PlayerInput : MonoBehaviour
{
    
    private InputAction move;
    private InputAction look;
    [SerializeField] private float maxSpeed = 10.0f;
    [SerializeField] private float gravity = -30.0f;
    [SerializeField] private float rotationSpeed = 4.0f;
    [SerializeField] private float mouseSensY = 5.0f;
    private Vector3 velocity;
    [SerializeField, Self] private CharacterController controller;
    [SerializeField, Child] private Camera cam;

    private void OnValidate()
    {
        this.ValidateRefs();
    }

    void Start()
    {
        move = InputSystem.actions.FindAction("Player/Move");
        look = InputSystem.actions.FindAction("Player/Look");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 readMove = move.ReadValue<Vector2>();
        Vector2 readLook = look.ReadValue<Vector2>();

        //Movement of the player
        Vector3 movement = transform.right * readMove.x + transform.forward * readMove.y;
        velocity.y += gravity * Time.deltaTime;
        movement *= maxSpeed * Time.deltaTime;
        movement += velocity;
        controller.Move(movement);

        //Rotation of the player
        transform.Rotate(Vector3.up, readLook.x * rotationSpeed * Time.deltaTime);

        //Rotation of the camera
        mouseSensY = mouseSensY * readLook.y;
        mouseSensY = Mathf.Clamp(mouseSensY, -90f, 90f);
        cam.gameObject.transform.localRotation = Quaternion.Euler(mouseSensY, 0, 0);
    }
}
