using System.Runtime.CompilerServices;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MenuInput : MonoBehaviour
{

    private InputAction openMenu;
    [SerializeField] private GameObject menuPanel;

    [SerializeField] private bool isMenuOpen;
    void Start()
    {
        openMenu = InputSystem.actions.FindAction("UI/Menu");
        openMenu.started += ToggleMenu;
    }

    private void OnDisable()
    {
        openMenu.started -= ToggleMenu;
    }

    private void ToggleMenu(InputAction.CallbackContext context)
    {
        Debug.Log("Open menu caled pressing P");
        isMenuOpen = !isMenuOpen;
        menuPanel.SetActive(isMenuOpen);

        if (isMenuOpen)
        {
            GetComponent<PlayerInput>().enabled = false;
            InputSystem.actions.FindActionMap("Player").Disable();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        else
        {
            GetComponent<PlayerInput>().enabled = true;
            InputSystem.actions.FindActionMap("Player").Enable();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }


}
