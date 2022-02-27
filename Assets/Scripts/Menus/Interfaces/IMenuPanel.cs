public interface IMenuPanel
{
    MenuType MenuType { get;}
    bool IsMenuActive { get; }
    void Open();
    void Close();
}