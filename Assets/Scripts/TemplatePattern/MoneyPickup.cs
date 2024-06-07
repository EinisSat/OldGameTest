using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyPickup : Pickup
{
	[SerializeField] int gold = 100;
	protected override void OnPickup(PlayerController player)
	{
		PlayerCurrencySingleton money = player.GetComponent<PlayerCurrencySingleton>();
		money?.AddCurrency(gold);
	}
}
