using UnityEngine;
using UnityWeld.Binding;

[Binding]
public class InGameVM : VMBase
{
    [SerializeField] private string _levelText = "LEVEL ";
    
    [Binding]
    public string LevelText
    {
        get => _levelText;

        set
        {
            _levelText = value;
                
            OnPropertyChanged(nameof(LevelText));
        }
    }

    protected override void TryActivateCustomActions()
    {
        base.TryActivateCustomActions();
        
        InitBindings();
    }

    private void InitBindings()
    {
        LevelText = _levelText + UserSaveManager.Instance.GetVirtualLevelID();
    }
    
    protected override void AwakeCustomActions()
    {
        base.AwakeCustomActions();
        
        TryDeactivate();
    }
}