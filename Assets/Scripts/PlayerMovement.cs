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
    [SerializeField] private float rayDistance = 2f;
    [SerializeField] private Transform rayCastPoint;
    
    private Vector2 direciton;
    private Vector3 rayCastOriginalPosition;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Vector2 lastDirection;
    private IInteractable lastInteractable;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = rootVisual.GetComponent<SpriteRenderer>();
        rayCastOriginalPosition = rayCastPoint.localPosition;
    }

    private void Start()
    {
        movementInput.OnValueChanged += OnMovementInputChanged;
        interactInput.OnRaised += OnInteractInputRaised;
        
    }

    private void OnInteractInputRaised()
    {
        RaycastHit2D hit = Physics2D.Raycast(rayCastPoint.position, lastDirection, rayDistance);
        
        if (!hit) return;
        Debug.Log(hit.collider.name);
        if (hit.collider != null && hit.collider.gameObject.TryGetComponent(out IInteractable interactable))
        {
            interactable.Interact(gameObject);
        }
    }

    private void OnMovementInputChanged(Vector2 direciton)
    {
        if (!(direciton.Equals(lastDirection) || direciton.Equals(Vector2.zero)))
        {
            lastDirection = direciton;
        }
        this.direciton = direciton.normalized;
    }

    public void Update()
    {
        Debug.DrawRay(rayCastPoint.position, lastDirection * rayDistance, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(rayCastPoint.position, lastDirection, rayDistance);
        if (hit && hit.collider.gameObject.TryGetComponent(out IInteractable interactable))
        {
            lastInteractable = interactable;
            interactable.Select(gameObject);
        }
        else if (lastInteractable != null)
        {
            lastInteractable.Deselect(gameObject);
            lastInteractable = null;
        }
        Move();
        OrientSprite();
    }

    private void OrientSprite()
    {
        if (rb.linearVelocity.x < 0)
        {
            rayCastPoint.localPosition = new Vector3(rayCastOriginalPosition.x, rayCastOriginalPosition.y, 0);
            sr.flipX = false;
            
        }
        
        if (rb.linearVelocity.x > 0)
        {
            rayCastPoint.localPosition = new Vector3(-rayCastOriginalPosition.x, rayCastOriginalPosition.y, 0);
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
