using UnityWeld.Binding;

[Binding]
public class WinGameVM : VMBase
{
    protected override void AwakeCustomActions()
    {
        base.AwakeCustomActions();
        
        TryDeactivate();
    }

    [Binding]
    public void LoadNextScene()
    {
        GameStateController.Instance.LoadNextLevel();
    }
}