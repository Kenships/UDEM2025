using System.Collections.Generic;
using Obvious.Soap;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(BoxCollider2D))]
public abstract class Appliance : MonoBehaviour, IInteractable
{
    [SerializeField] protected GameObject rootVisual;
    [SerializeField] protected GameObject selectionVisual1;
    [SerializeField] protected GameObject selectionVisual2;
    [SerializeField] protected GameObject activeVisual;
    [SerializeField] protected GameObject popupWindow;
    protected List<GameObject> playersInteracting;

    private void Awake()
    {
        playersInteracting = new List<GameObject>();
    }
    public void Start()
    {
        selectionVisual1.SetActive(false);
        selectionVisual2.SetActive(false);
        activeVisual.SetActive(false);
    }
    
    public abstract void Interact(GameObject player);
    public void Select(GameObject player)
    {
        PlayerInput playerInput = player.GetComponent<PlayerInput>();
        
        if (playerInput.GetPlayerNumber() == 1)
        {
            selectionVisual1.SetActive(true);
        }
        else if(playerInput.GetPlayerNumber() == 2)
        {
            selectionVisual2.SetActive(true);
        }
    }
    
    public void Deselect(GameObject player)
    {
        PlayerInput playerInput = player.GetComponent<PlayerInput>();
        
        if (playerInput.GetPlayerNumber() == 1)
        {
            selectionVisual1.SetActive(false);
        }
        else if(playerInput.GetPlayerNumber() == 2)
        {
            selectionVisual2.SetActive(false);
        }
    }

    protected void InteractMode(GameObject player)
    {
        activeVisual.SetActive(true);
        
        PlayerInput playerInput = player.GetComponent<PlayerInput>();
        
        playerInput.cancelInput.OnRaised += Exit;
        
        playerInput.SetUIMap();
        
        playersInteracting.Add(player);
    }
    
    protected void MovementMode(GameObject player)
    {
        PlayerInput playerInput = player.GetComponent<PlayerInput>();
        playerInput.SetMovementMap();
        activeVisual.SetActive(false);
        
        playersInteracting.Remove(player);

        if (playersInteracting.Count == 0)
        {
            activeVisual.SetActive(false);
        }
    }
    
    

    public abstract void Exit(GameObject player);
}
