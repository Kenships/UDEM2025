using System;
using UnityEngine;
using UnityEngine.UI;


public class ItemFrameUpdater : MonoBehaviour
{
    [SerializeField] private GameObject frame;
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private ItemSOVariable item;

    private void Start()
    {
        // Subscribe to value changes
        item.OnValueChanged += OnItemChanged;
    }

    private void OnDestroy()
    {
        // Unsubscribe to prevent memory leaks
        item.OnValueChanged -= OnItemChanged;
    }

    private void OnItemChanged(ItemSO obj)
    {
        // Remove all existing children
        for (int i = frame.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(frame.transform.GetChild(i).gameObject);
        }

        // Instantiate the new item UI
        var itemObject = Instantiate(itemPrefab, frame.transform);
        var image = itemObject.GetComponent<Image>();
        if (image != null)
        {
            image.sprite = item.Value.sprite;
        }
        else
        {
            Debug.LogWarning("Item prefab does not have an Image component.");
        }
    }
}
