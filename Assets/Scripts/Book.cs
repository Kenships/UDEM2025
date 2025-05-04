using System.Collections;
using UnityEngine;

public class Book : Appliance
{
    [SerializeField] private float duration = 0.1f;
    public override void Interact(GameObject player)
    {
        activeVisual.SetActive(true);
        StartCoroutine(WaitForSeconds(duration, player));
        
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