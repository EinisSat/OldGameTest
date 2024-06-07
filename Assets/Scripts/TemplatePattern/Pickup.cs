using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
	protected abstract void OnPickup(PlayerController player);

	private new CircleCollider2D collider;
	private void Awake()
	{
		collider = GetComponent<CircleCollider2D>();
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		PlayerController player = collision.GetComponent<PlayerController>();
		if (player == null)
		{
			return;
		}

		OnPickup(player);

		Disable();
	}
	protected virtual void Disable()
	{
		gameObject.SetActive(false);
	}
}
