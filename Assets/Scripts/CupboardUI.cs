using System;
using UnityEngine;
using UnityEngine.UI;


public class CupboardUI : MonoBehaviour
{
    [SerializeField] private Button flour;
    [SerializeField] private Button peanuts;
    [SerializeField] private Button sprinkles;
    [SerializeField] private Button sugar;

    [SerializeField] private ItemSO flourSO;
    [SerializeField] private ItemSO peanutsSO;
    [SerializeField] private ItemSO sprinklesSO;
    [SerializeField] private ItemSO sugarSO;
    
    [SerializeField] private ItemSOVariable itemSOVariable1;
    [SerializeField] private ItemSOVariable itemSOVariable2;

    private int playerNumber;
    private void Start()
    {
        flour.onClick.AddListener(OnFlour);
        peanuts.onClick.AddListener(OnPeanuts);
        sprinkles.onClick.AddListener(OnSprinkles);
        sugar.onClick.AddListener(OnSugar);
    }
    
    public void Initialize(GameObject player)
    {
        PlayerInput playerInput = player.GetComponent<PlayerInput>();
        playerNumber = playerInput.GetPlayerNumber();
    }

    private void OnSugar()
    {
        if (playerNumber == 1)
        {
            itemSOVariable1.Value = sugarSO;
        }
        else if (playerNumber == 2)
        {
            itemSOVariable2.Value = sugarSO;
        }
    }

    private void OnSprinkles()
    {
        if (playerNumber == 1)
        {
            itemSOVariable1.Value = sprinklesSO;
        }
        else if (playerNumber == 2)
        {
            itemSOVariable2.Value = sprinklesSO;
        }
    }

    private void OnPeanuts()
    {
        if (playerNumber == 1)
        {
            itemSOVariable1.Value = peanutsSO;
        }
        else if (playerNumber == 2)
        {
            itemSOVariable2.Value = peanutsSO;
        }
        
    }

    private void OnFlour()
    {
        if (playerNumber == 1)
        {
            itemSOVariable1.Value = flourSO;
        }
        else if (playerNumber == 2)
        {
            itemSOVariable2.Value = flourSO;
        }
    }
}
