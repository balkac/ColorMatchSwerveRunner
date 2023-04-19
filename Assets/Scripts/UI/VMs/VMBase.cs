using System.ComponentModel;
using UnityEngine;

public abstract class VMBase : MonoBehaviour, INotifyPropertyChanged
{
	[SerializeField] private GameObject _parentCanvas;
	public event PropertyChangedEventHandler PropertyChanged;
	protected void OnPropertyChanged(string propertyName)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
	private void Awake()
	{
		AwakeCustomActions();
	}

	protected virtual void AwakeCustomActions()
	{
	}
	protected virtual void TryActivateCustomActions()
	{
	}

	protected virtual void TryDeactivateCustomActions()
	{
	}
	
	public void TryActivate()
	{
		_parentCanvas.SetActive(true);
		
		TryActivateCustomActions();
	}

	public void TryDeactivate()
	{
		_parentCanvas.SetActive(false);
		
		TryDeactivateCustomActions();
	}
	
}