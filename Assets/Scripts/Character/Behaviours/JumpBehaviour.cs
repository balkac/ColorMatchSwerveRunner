using System;
using DG.Tweening;
using UnityEngine;

public class JumpBehaviour : MonoBehaviour
{
	[SerializeField] private Transform _characterContainerTransform;
	
	public Action OnJumpStarted;

	public Action OnJumpStopped;

	private void OnTriggerEnter(Collider other)
	{
		if(other.TryGetComponent(out JumpRamp jumpRamp))
		{
			OnJumpStarted?.Invoke();
			_characterContainerTransform.DOJump(jumpRamp.TargetTransform.position, 10f, 1, 2f).OnComplete(
				() =>
				{
					OnJumpStopped?.Invoke();
				}
			);
		}
	}
}