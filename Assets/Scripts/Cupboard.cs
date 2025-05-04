using System.Collections;
using UnityEngine;

public class Cupboard : Appliance
{
    [SerializeField] private GameObject cupboardUIPrefab;
    public override void Interact(GameObject player)
    {
        InteractMode(player);
        PlayerInput playerInput = player.GetComponent<PlayerInput>();
        if (playerInput.GetPlayerNumber() == 1)
        {
            GameObject UI = Instantiate(cupboardUIPrefab, PopupManager.Instance.leftPopup.transform);
            CupboardUI fridgeUI = UI.GetComponent<CupboardUI>();
            fridgeUI.Initialize(player);
        }
        else if(playerInput.GetPlayerNumber() == 2)
        {
            GameObject UI = Instantiate(cupboardUIPrefab, PopupManager.Instance.rightPopup.transform);
            CupboardUI fridgeUI = UI.GetComponent<CupboardUI>();
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