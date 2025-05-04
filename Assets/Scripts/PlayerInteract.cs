using Obvious.Soap;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private ScriptableEventNoParam interactEvent;
    [SerializeField] private ScriptableEventBool popupEvent;

    private bool isOpen;
    private void Start()
    {
        interactEvent.OnRaised += OnInteractEventRaised;
    }

    private void OnInteractEventRaised()
    {
        popupEvent.Raise(isOpen);
        isOpen = !isOpen;
    }
}
