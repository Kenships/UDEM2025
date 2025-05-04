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

    public abstract void Exit(GameObject player);
}
