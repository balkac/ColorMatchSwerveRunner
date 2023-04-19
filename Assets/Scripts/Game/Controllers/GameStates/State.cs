using UnityEngine;

public enum EState
{
	None = 0,
	MainMenu = 1,
	Run = 2,
	Win = 3,
	Lose = 4,
}
public abstract class State : MonoBehaviour
{
	[SerializeField] private EState _stateType;

	public EState StateType => _stateType;

	private GameStateController _gameStateController;
	protected State(GameStateController gameStateController)
	{
		_gameStateController = gameStateController;
	}

	public virtual void OnEnter()
	{
	}
	public virtual void OnExit()
	{
	}
}