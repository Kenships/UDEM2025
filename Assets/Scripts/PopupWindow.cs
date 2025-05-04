using System;
using Obvious.Soap;
using UnityEngine;
using UnityEngine.UI;

public class PopupWindow : MonoBehaviour
{

    [SerializeField] private Button startButton;

    private void Start()
    {
        startButton.Select();
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

    public void Hide()
    {
       gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
}
