
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
    
        if (playerInput.GetPlayerNumber() == 1)
        {
            Instantiate(popupWindow, PopupManager.Instance.leftPopup.transform);
        }
        else if(playerInput.GetPlayerNumber() == 2)
        {
            Instantiate(popupWindow, PopupManager.Instance.rightPopup.transform);
        }
        
        
        playersInteracting.Add(player);
        activeVisual.SetActive(true);
    }

    public override void Exit(GameObject player)
    {
        PlayerInput playerInput = player.GetComponent<PlayerInput>();
        
        playerInput.SetMovementMap();
        
        if (playerInput.GetPlayerNumber() == 1)
        {
            Destroy(PopupManager.Instance.leftPopup.transform.GetChild(0).gameObject);
        }
        else if(playerInput.GetPlayerNumber() == 2)
        {
            Destroy(PopupManager.Instance.rightPopup.transform.GetChild(0).gameObject);
        }

        playersInteracting.Remove(player);

        if (playersInteracting.Count == 0)
        {
            activeVisual.SetActive(false);
        }
    }
    
    
}