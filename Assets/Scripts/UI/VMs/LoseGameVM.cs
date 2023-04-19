using UnityWeld.Binding;

[Binding]
public class LoseGameVM : VMBase
{
	protected override void AwakeCustomActions()
	{
		base.AwakeCustomActions();
		
		TryDeactivate();
	}

	[Binding]

	public void ReplayLevel()
	{
		GameStateController.Instance.ReplayLevel();
	}
		
}