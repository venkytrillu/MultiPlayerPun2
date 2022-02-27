using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIErrorMenu : MenuPanel
{
    [SerializeField] private TextMeshProUGUI _titleNameTxt; 
    
    [SerializeField] private Button okBtn;

    private void Start()
    {
        okBtn.onClick.AddListener(handleOkButton);
    }

    private void handleOkButton()
    {
        UIMenuManager.Instance.OpenMenu(MenuType.MainMenu);
    }
}