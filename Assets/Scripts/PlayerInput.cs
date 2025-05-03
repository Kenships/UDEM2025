using System;
using Obvious.Soap;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private int playerNumber;
    private InputSystem_Actions inputActions;
    [SerializeField] private Vector2Variable movementInput;
    [SerializeField] private ScriptableEventNullObject interactInput;

    public void Awake()
    {
        Initialize(playerNumber);
    }

    private void Initialize(int playerNumber)
    {
        inputActions = new InputSystem_Actions();
        
        if(playerNumber == 1)
        {
            SubscribeToPlayer1Actions();
        }
        else if(playerNumber == 2)
        {
            SubscribeToPlayer2Actions();
        }
    }

    private void SubscribeToPlayer2Actions()
    {
        inputActions.Player2.Enable();
        inputActions.Player2.Move.performed += OnMove;
        inputActions.Player2.Move.canceled += OnMove;
        inputActions.Player2.Interact.performed += OnInteract;
    }

    private void SubscribeToPlayer1Actions()
    {
        inputActions.Player1.Enable();
        inputActions.Player1.Move.performed += OnMove;
        inputActions.Player1.Move.canceled += OnMove;
        inputActions.Player1.Interact.performed += OnInteract;
    }

    private void OnInteract(InputAction.CallbackContext obj)
    {
        Debug.Log("Interact");
        interactInput.Raise(new NullObject());
    }

    private void OnMove(InputAction.CallbackContext obj)
    {
        movementInput.Value = obj.ReadValue<Vector2>();
    }
}
