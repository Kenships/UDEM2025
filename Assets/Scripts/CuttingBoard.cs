using System.Collections;
using UnityEngine;

public class CuttingBoard : Appliance
{
    [SerializeField] private float duration = 0.1f;
    [SerializeField] private ItemSO Strawberry;
    [SerializeField] private ItemSO StrawberryCut;
    [SerializeField] private ItemSO Lime;
    [SerializeField] private ItemSO LimeCut;
    public override void Interact(GameObject player)
    {
        activeVisual.SetActive(true);
        StartCoroutine(WaitForSeconds(duration, player));
        Inventory inventory = player.GetComponent<Inventory>();
        if(inventory.GetItem().Value == null)
        {
            return;
        }
        if (inventory.GetItem().Value.Equals(Strawberry))
        {
            inventory.GetItem().Value = StrawberryCut;
        }
        else if (inventory.GetItem().Value.Equals(Lime))
        {
            inventory.GetItem().Value = LimeCut;
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

