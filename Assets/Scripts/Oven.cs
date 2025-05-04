
using System;
using System.Collections.Generic;
using UnityEngine;

public class Oven : Appliance
{
    public override void Interact(GameObject player)
    {
        PlayerInput playerInput = player.GetComponent<PlayerInput>();
        
        playerInput.SetUIMap();
        playerInput.cancelInput.OnRaised += Exit;
        
        
        playersInteracting.Add(player);
        activeVisual.SetActive(true);
    }

    public override void Exit(GameObject player)
    {
        PlayerInput playerInput = player.GetComponent<PlayerInput>();
        Debug.Log(playerInput.GetPlayerNumber());
        playerInput.SetMovementMap();
        playerInput.cancelInput.OnRaised -= Exit;
        
        
        playersInteracting.Remove(player);

        if (playersInteracting.Count == 0)
        {
            activeVisual.SetActive(false);
        }
    }
    
    
}