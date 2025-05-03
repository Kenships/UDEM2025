using System;
using Obvious.Soap;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    
    [SerializeField] private Vector2Variable movementInput;

    private Vector2 direciton;
    private void Start()
    {
        movementInput.OnValueChanged += OnMovementInputChanged;
    }
    private void OnMovementInputChanged(Vector2 direciton)
    {
        this.direciton = direciton.normalized;
    }

    public void Update()
    {
        transform.position += (Vector3)direciton * (speed * Time.deltaTime);
    }
}
