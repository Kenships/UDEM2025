using System;
using UnityEngine;
using UnityEngine.UI;

public class FridgeUI : MonoBehaviour
{
    [SerializeField] private Button butter;
    [SerializeField] private Button eggs;
    [SerializeField] private Button icing;
    [SerializeField] private Button lime;
    [SerializeField] private Button strawberry;
    [SerializeField] private Button milk;
    [SerializeField] private Button cream;
    [SerializeField] private ItemSO butterSO;
    [SerializeField] private ItemSO eggsSO;
    [SerializeField] private ItemSO icingSO;
    [SerializeField] private ItemSO limeSO;
    [SerializeField] private ItemSO strawberrySO;
    [SerializeField] private ItemSO milkSO;
    [SerializeField] private ItemSO creamSO;
    [SerializeField] private ItemSOVariable itemSOVariable1;
    [SerializeField] private ItemSOVariable itemSOVariable2;
    private int playerNumber;
    private void Start()
    {
        butter.Select();
        butter.onClick.AddListener(OnButter);
        eggs.onClick.AddListener(OnEggs);
        icing.onClick.AddListener(OnIcing);
        lime.onClick.AddListener(OnLime);
        strawberry.onClick.AddListener(OnStrawberry);
        milk.onClick.AddListener(OnMilk);
        cream.onClick.AddListener(OnCream);
    }

    public void Initialize(GameObject player)
    {
        PlayerInput playerInput = player.GetComponent<PlayerInput>();
        playerNumber = playerInput.GetPlayerNumber();
    }

    private void OnCream()
    {
        Debug.Log("Cream");
        if (playerNumber == 1)
        {
            itemSOVariable1.Value = creamSO;
        }
        else if (playerNumber == 2)
        {
            itemSOVariable2.Value = creamSO;
        }
    }

    private void OnMilk()
    {
        Debug.Log("Milk");
        if (playerNumber == 1)
        {
            itemSOVariable1.Value = milkSO;
        }
        else if (playerNumber == 2)
        {
            itemSOVariable2.Value = milkSO;
        }
    }

    private void OnStrawberry()
    {
        Debug.Log("Strawberry");
        if (playerNumber == 1)
        {
            itemSOVariable1.Value = strawberrySO;
        }
        else if (playerNumber == 2)
        {
            itemSOVariable2.Value = strawberrySO;
        }
    }

    private void OnLime()
    {
        Debug.Log("Lime");
        if (playerNumber == 1)
        {
            itemSOVariable1.Value = limeSO;
        }
        else if (playerNumber == 2)
        {
            itemSOVariable2.Value = limeSO;
        }
    }

    private void OnIcing()
    {
        Debug.Log("Icing");
        if (playerNumber == 1)
        {
            itemSOVariable1.Value = icingSO;
        }
        else if (playerNumber == 2)
        {
            itemSOVariable2.Value = icingSO;
        }
    }

    private void OnEggs()
    {
        Debug.Log("Eggs");
        if (playerNumber == 1)
        {
            itemSOVariable1.Value = eggsSO;
        }
        else if (playerNumber == 2)
        {
            itemSOVariable2.Value = eggsSO;
        }
    }

    private void OnButter()
    {
        Debug.Log("Butter");
        if (playerNumber == 1)
        {
            itemSOVariable1.Value = butterSO;
        }
        else if (playerNumber == 2)
        {
            itemSOVariable2.Value = butterSO;
        }
    }
    
}
