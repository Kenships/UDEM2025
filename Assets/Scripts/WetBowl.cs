using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WetBowl : Appliance
{
    [SerializeField] private float duration = 0.1f;
    [SerializeField] private ItemSO sugar;
    [SerializeField] private ItemSO butter;
    [SerializeField] private ItemSO egg;
    [SerializeField] private ItemSO yolk;
    [SerializeField] private ItemSO milk;
    [SerializeField] private ItemSO wetBatter;
    [SerializeField] private ItemSO Batter;
    [SerializeField] private ItemSO eggWhite;
    [SerializeField] private ItemSO flour;
    [SerializeField] private ItemSO powderedSugar;
    [SerializeField] private ItemSO powderedFlour;

    [SerializeField] private GameObject bowlHolder;
    [SerializeField] private GameObject itemPrefab;
    private List<ItemSO> items = new List<ItemSO>();
    public override void Interact(GameObject player)
    {
        activeVisual.SetActive(true);
        
        StartCoroutine(WaitForSeconds(duration, player));
        
        Inventory inventory = player.GetComponent<Inventory>();
        if(inventory.GetItem().Value == null)
        {
            return;
        }
        if (inventory.GetItem().Value.Equals(sugar) && !items.Contains(sugar))
        {
            items.Add(sugar);
        }
        else if (inventory.GetItem().Value.Equals(egg)&& !items.Contains(egg))
        {
            items.Add(yolk);
            items.Add(eggWhite);

        }
        else if (inventory.GetItem().Value.Equals(butter)&& !items.Contains(butter))
        {
            items.Add(butter);
        }
        else if (inventory.GetItem().Value.Equals(milk)&& !items.Contains(milk))
        {
            items.Add(milk);
        }
        else if (inventory.GetItem().Value.Equals(flour)&& !items.Contains(flour))
        {
            items.Add(powderedFlour);
        }

        if (items.Count == 6)
        {
            inventory.GetItem().Value = Batter;
        }
    }

    public override void Exit(GameObject player)
    {
        activeVisual.SetActive(false);
    }
    
    private IEnumerator WaitForSeconds(float time, GameObject player)
    {
        
        yield return new WaitForSeconds(time);
        Exit(player);
    }
}