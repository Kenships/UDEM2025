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
    [SerializeField] private Vector2Variable UIMovementInput;
    [SerializeField] private ScriptableEventNoParam interactInput;
    [SerializeField] public ScriptableEventGameObject submitInput;
    [SerializeField] public ScriptableEventGameObject cancelInput;
    
    private IInteractable interactable;

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
        
        inputActions.UI2.Navigate.performed += OnNavigate;
        inputActions.UI2.Navigate.canceled += OnNavigate;
        inputActions.UI2.Submit.performed += OnSubmit;
        inputActions.UI2.Cancel.performed += OnCancel;
    }

    private void OnCancel(InputAction.CallbackContext obj)
    {
        cancelInput.Raise(transform.gameObject);
    }

    private void OnSubmit(InputAction.CallbackContext obj)
    {
        submitInput.Raise(transform.gameObject);
    }

    private void OnNavigate(InputAction.CallbackContext obj)
    {
        UIMovementInput.Value = obj.ReadValue<Vector2>();
    }

    private void SubscribeToPlayer1Actions()
    {
        inputActions.Player1.Enable();
        inputActions.Player1.Move.performed += OnMove;
        inputActions.Player1.Move.canceled += OnMove;
        inputActions.Player1.Interact.performed += OnInteract;
        
        inputActions.UI1.Navigate.performed += OnNavigate;
        inputActions.UI1.Navigate.canceled += OnNavigate;
        inputActions.UI1.Submit.performed += OnSubmit;
        inputActions.UI1.Cancel.performed += OnCancel;
    }

    private void OnInteract(InputAction.CallbackContext obj)
    {
        interactInput.Raise();
    }

    private void OnMove(InputAction.CallbackContext obj)
    {
        movementInput.Value = obj.ReadValue<Vector2>();
    }

    public void SetUIMap()
    {
        inputActions.Player1.Disable();
        inputActions.Player2.Disable();

        if (playerNumber == 1)
        {
            inputActions.UI1.Enable();
        }
        else if (playerNumber == 2)
        {
            inputActions.UI2.Enable();
        }
    }

    public void SetMovementMap()
    {
        inputActions.UI1.Disable();
        inputActions.UI2.Disable();
        
        if (playerNumber == 1)
        {
            inputActions.Player1.Enable();
        }
        else if (playerNumber == 2)
        {
            inputActions.Player2.Enable();
        }
    }

    public int GetPlayerNumber()
    {
        return playerNumber;
    }
}
