using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Pickup
{
	[SerializeField] float healValue = 1;
	protected override void OnPickup(PlayerController player)
	{
		Health health = player.GetComponent<Health>();
		health?.AddHealth(healValue);
	}
}
