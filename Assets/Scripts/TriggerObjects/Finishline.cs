﻿using System;
using UnityEngine;

public class Finishline : Singleton<Finishline>
{
	public Action OnFinishLineTriggered;

	private void OnTriggerEnter(Collider other)
	{
		if(other.TryGetComponent(out Character character))
		{
			OnFinishLineTriggered?.Invoke();
		}
	}
}