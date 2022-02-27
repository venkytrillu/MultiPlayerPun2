public interface IUIManager
{
    void OpenMenu(MenuType menuType);

    void OpenMenu(MenuPanel menuPanel);
    
    MenuPanel GetMenu(MenuType menuType);
    void Quit();
}