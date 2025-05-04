using System.Collections;
using UnityEngine;

public class Cupboard : Appliance
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