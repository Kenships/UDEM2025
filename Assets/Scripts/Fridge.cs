using UnityEngine;

public class Fridge : Appliance
{
    [SerializeField] GameObject fridgeUIPrefab;
    public override void Interact(GameObject player)
    {
        InteractMode(player);
        PlayerInput playerInput = player.GetComponent<PlayerInput>();
        if (playerInput.GetPlayerNumber() == 1)
        {
            GameObject UI = Instantiate(fridgeUIPrefab, PopupManager.Instance.leftPopup.transform);
            FridgeUI fridgeUI = UI.GetComponent<FridgeUI>();
            fridgeUI.Initialize(player);
        }
        else if(playerInput.GetPlayerNumber() == 2)
        {
            GameObject UI = Instantiate(fridgeUIPrefab, PopupManager.Instance.rightPopup.transform);
            FridgeUI fridgeUI = UI.GetComponent<FridgeUI>();
            fridgeUI.Initialize(player);
        }
    }

    public override void Exit(GameObject player)
    {
        MovementMode(player);
        PlayerInput playerInput = player.GetComponent<PlayerInput>();
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