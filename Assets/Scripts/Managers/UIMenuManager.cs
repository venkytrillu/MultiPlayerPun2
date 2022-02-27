using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIMenuManager : GenericSingletonClass<UIMenuManager>, IUIManager
{
    [SerializeField] private List<MenuPanel> _menuPanels = new List<MenuPanel>();
    
    private void Start()
    {
        OpenMenu(MenuType.LoadingMenu);
    }

    public void OpenMenu(MenuType menuType)
    {
        foreach (var menu in _menuPanels)
        {
            if (menu.MenuType == menuType)
            {
                menu.Open();
            }
            else if(menu.IsMenuActive)
            {
                menu.Close();
            }
        }
    }

    public void OpenMenu(MenuPanel menuPanel)
    {
        menuPanel.Open();
    }

    public MenuPanel GetMenu(MenuType menuType)
    {
       return _menuPanels.FirstOrDefault(x => x.MenuType == menuType);
    }

    public void Quit()
    {
        Application.Quit();
    }
}