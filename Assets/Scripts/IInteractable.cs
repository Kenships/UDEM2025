using UnityEngine;

public interface IInteractable
{
    public void Interact(GameObject player);
    public void Select(GameObject player);
    public void Deselect(GameObject player);
    public void Exit(GameObject player);
}
