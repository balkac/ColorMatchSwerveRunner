using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Collectible : MonoBehaviour
{
	[SerializeField] private ECollectible _collectibleType;
	public ECollectible CollectibleType => _collectibleType;

	[SerializeField] private Collider _collider;

	[SerializeField] private float scatterForce = 10f;

	[SerializeField] private float scatterDuration = 0.5f;
	public Collider Collider => _collider;

	private bool _isCollected;

	public Action<Collectible> OnObstacleCollided;
	
	public bool TryCollect()
	{
		if (!_isCollected)
		{
			_isCollected = true;
			return true;
		}

		return false;
	}

	public void SetHeight(float height)
	{
		transform.localPosition = new Vector3(0, height, 0);
	}

	public void IncreaseHeight(float increaseAmount)
	{
		transform.localPosition = new Vector3(0, transform.localPosition.y + increaseAmount, 0);
	}
	public void DecreaseHeight(float decreaseAmount)
	{
		transform.localPosition = new Vector3(0, transform.localPosition.y - decreaseAmount, 0);
	}

	public void DestroyCollectible()
	{
		this.transform.parent = null;
		this.Collider.enabled = false;
		this.gameObject.SetActive(false);
	}
	
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.TryGetComponent(out Obstacle obstacle))
		{
			if (obstacle.TryCollide())
			{
				transform.parent = null;
				
				StartCoroutine(ForceRoutine(scatterDuration));
				
				OnObstacleCollided?.Invoke(this);	
			}
		}
	}
	
	private IEnumerator ForceRoutine(float duration)
	{
		Rigidbody rb = GetComponent<Rigidbody>();

		rb.isKinematic = false;
		
		Vector3 scatterDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(0f, 1f), Random.Range(-1f, 0f)).normalized;
		
		Vector3 scatterForceVector = scatterDirection * scatterForce;
		
		rb.AddForce(scatterForceVector, ForceMode.Impulse);
		
		float time = 0;

		while (time<duration)
		{
			time += Time.deltaTime;
			
			yield return null;
		}

		rb.velocity = Vector3.zero;

		rb.useGravity = true;
	}
}