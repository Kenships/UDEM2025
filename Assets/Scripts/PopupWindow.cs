using System;
using Obvious.Soap;
using UnityEngine;

public class PopupWindow : MonoBehaviour
{
    [SerializeField] ScriptableEventBool popupEvent;

    private void Start()
    {
        popupEvent.OnRaised += OnPopupEventRaised;
    }

    private void OnPopupEventRaised(bool isOpen)
    {
        if (isOpen)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Hide()
    {
       gameObject.SetActive(false);
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }
}
