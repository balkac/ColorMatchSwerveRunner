using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private ObstacleHandler _obstacleHandler;

    private void Awake()
    {
        _obstacleHandler.OnCharacterFailed += OnCharacterFailed;
    }

    private void OnDestroy()
    {
        _obstacleHandler.OnCharacterFailed -= OnCharacterFailed;
    }

    private void OnCharacterFailed()
    {
        GameStateController.Instance.OnCharacterFailed();
    }
}