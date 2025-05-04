
using UnityEngine;

public class Oven : Appliance
{
    public override void Interact(GameObject player)
    {
        PlayerInput playerInput = player.GetComponent<PlayerInput>();

        playerInput.cancelInput.OnRaised += Exit;
        
        playerInput.SetUIMap();

        if (playerInput.GetPlayerNumber() == 1)
        {
            Instantiate(popupWindow, PopupManager.Instance.leftPopup.transform);
        }
        else if(playerInput.GetPlayerNumber() == 2)
        {
            Instantiate(popupWindow, PopupManager.Instance.leftPopup.transform);
        }
    }

    public override void Exit(GameObject player)
    {
        PlayerInput playerInput = player.GetComponent<PlayerInput>();
        playerInput.cancelInput.OnRaised -= Exit;
        playerInput.SetMovementMap();
        
        if (playerInput.GetPlayerNumber() == 1)
        {
            Destroy(PopupManager.Instance.leftPopup.transform.GetChild(0).gameObject);
        }
        else if(playerInput.GetPlayerNumber() == 2)
        {
            Destroy(PopupManager.Instance.rightPopup.transform.GetChild(0).gameObject);
        }
    }
}