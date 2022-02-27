using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPanel : MonoBehaviour, IMenuPanel
{
    [SerializeField] private MenuType menuType;
    public MenuType MenuType => menuType;
    public bool IsMenuActive => gameObject.activeSelf;

    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}