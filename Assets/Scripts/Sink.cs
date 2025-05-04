
using UnityEngine;

public class Sink : Appliance
{
    public override void Interact(GameObject player)
    {
        InteractMode(player);
    }

    public override void Exit(GameObject player)
    {
        MovementMode(player);
    }
}