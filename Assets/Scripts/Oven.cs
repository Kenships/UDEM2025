
using System;
using System.Collections.Generic;
using UnityEngine;

public class Oven : Appliance
{
    [SerializeField] private ItemSO batter;
    [SerializeField] private ItemSO cake;
    public override void Interact(GameObject player)
    {
        AudioManager.Instance.Play(AudioManager.SoundType.Door_Open);
        PlayerInput playerInput = player.GetComponent<PlayerInput>();
        
        playerInput.SetUIMap();
        playerInput.cancelInput.OnRaised += Exit;
        
        
        
        playersInteracting.Add(player);
        activeVisual.SetActive(true);
        
        Inventory inventory = player.GetComponent<Inventory>();
        if (inventory.GetItem().Value == null)
        {
            return;
        }
        if (inventory.GetItem().Value.Equals(batter))
        {
            inventory.GetItem().Value = cake;
        }
    }

    public override void Exit(GameObject player)
    {
        AudioManager.Instance.Play(AudioManager.SoundType.Door_Close);
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