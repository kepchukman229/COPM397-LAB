using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    
    private InputAction inputs;

    void Start()
    {
        move = InputSystem.actions.FindAction("Player/Move");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 readMove = move.ReadValue<Vector2>();
        Debug.Log(readMove);    
    }
}
