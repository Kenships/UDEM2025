using Obvious.Soap;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private ScriptableEventNullObject interactEvent;
    [SerializeField] private ScriptableEventBool popupEvent;

    private bool isOpen;
    private void Start()
    {
        interactEvent.OnRaised += OnInteractEventRaised;
    }

    private void OnInteractEventRaised(NullObject obj)
    {
        popupEvent.Raise(isOpen);
        isOpen = !isOpen;
    }
}
