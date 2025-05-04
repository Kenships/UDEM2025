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
    
    
    public abstract void Interact(GameObject player);
    public abstract void Exit(GameObject player);
}
