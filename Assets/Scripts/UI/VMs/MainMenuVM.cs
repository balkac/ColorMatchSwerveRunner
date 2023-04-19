using UnityWeld.Binding;

[Binding]
public class MainMenuVM : VMBase
{
    [Binding]
    public void StartGame()
    {
        GameStateController.Instance.StartGame();
    }
}