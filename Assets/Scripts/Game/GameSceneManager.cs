using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    private void Awake()
    {
        LevelManager.Instance.LoadScene(UserSaveManager.Instance.GetCurLevelID());
    }
}