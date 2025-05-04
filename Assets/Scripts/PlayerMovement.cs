using System;
using Obvious.Soap;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float turningSpeed = 10f;
    
    [SerializeField] private Vector2Variable movementInput;
    [SerializeField] private ScriptableEventNoParam interactInput;

    [SerializeField] private GameObject rootVisual;
    
    private Vector2 direciton;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Vector2 lastDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = rootVisual.GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        movementInput.OnValueChanged += OnMovementInputChanged;
        interactInput.OnRaised += OnInteractInputRaised;
        
    }

    private void OnInteractInputRaised()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, lastDirection, 1f);
        
        if (!hit) return;
        Debug.Log(hit.collider.name);
        if (hit.collider != null && hit.collider.gameObject.TryGetComponent(out IInteractable interactable))
        {
            interactable.Interact(gameObject);
        }
    }

    private void OnMovementInputChanged(Vector2 direciton)
    {
        if (direciton.Equals(Vector2.zero))
        {
            lastDirection = this.direciton;
        }
        this.direciton = direciton.normalized;
    }

    public void Update()
    {
        Debug.DrawRay(transform.position, lastDirection, Color.red);
        Move();
        OrientSprite();
    }

    private void OrientSprite()
    {
        if (rb.linearVelocity.x < 0)
        {
            sr.flipX = false;
            
        }
        
        if (rb.linearVelocity.x > 0)
        {
            sr.flipX = true;
            
        }

        int rotation = sr.flipX ? 10 : -10;
        if (rb.linearVelocity.y > 0)
        {
            rootVisual.transform.rotation = Quaternion.Lerp(rootVisual.transform.rotation, Quaternion.Euler(0, 0, rotation), Time.deltaTime* turningSpeed);
        }
        else if(rb.linearVelocity.y < 0)
        {
            rootVisual.transform.rotation = Quaternion.Lerp(rootVisual.transform.rotation, Quaternion.Euler(0, 0, -rotation), Time.deltaTime* turningSpeed);
        }
        else
        {
            rootVisual.transform.rotation = Quaternion.Lerp(rootVisual.transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime* turningSpeed);
        }
    }

    private void Move()
    {
        rb.linearVelocity = (Vector3)direciton * speed;
    }
}
