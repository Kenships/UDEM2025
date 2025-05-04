using System;
using Obvious.Soap;
using UnityEngine;

public class PopupWindow : MonoBehaviour
{
    

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

    public void Hide()
    {
       gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
}
