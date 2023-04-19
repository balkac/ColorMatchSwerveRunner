using System;
using System.Collections.Generic;
using System.Linq;

public class GameStateController : Singleton<GameStateController>
{
    private State _currentState;
    private LevelManager _levelManager;
    private List<State> _states;
    public Action OnLevelStarted;

    private void Awake()
    {
        _levelManager = LevelManager.Instance;
        
        _states = GetComponentsInChildren<State>().ToList();
        
        Finishline.Instance.OnFinishLineTriggered += OnFinishLineTriggered;
    }

    private void Start()
    {
        SetState(EState.MainMenu);
    }

    private void OnDestroy()
    {
        Finishline.Instance.OnFinishLineTriggered -= OnFinishLineTriggered;
    }

    private void OnFinishLineTriggered()
    {
        SetState(EState.Win);
    }

    public void OnCharacterFailed()
    {
        SetState(EState.Lose);
    }

    public void StartGame()
    {
        SetState(EState.Run);
        
        OnLevelStarted?.Invoke();
    }
    
    public void ReplayLevel()
    {
        _levelManager.LoadScene(UserSaveManager.Instance.GetCurLevelID());
    }
    
    public void LoadNextLevel()
    {
        _levelManager.LoadScene(UserSaveManager.Instance.GetCurLevelID());
    }
    private void SetState(EState stateType)
    {
        if (_currentState != null)
        {
            if (_currentState.StateType == stateType)
            {
                return;
            }
        }

        foreach (var state in _states)
        {
            if (state.StateType == stateType)
            {
                if (_currentState != null)
                {
                    _currentState.OnExit();
                }

                _currentState = state;
                state.OnEnter();
            }
        }
    }
}