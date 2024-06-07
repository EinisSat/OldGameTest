using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : Pickup
{
	[SerializeField] private Sprite[] sprites;
	private SpriteRenderer sprite;

	private int number;
	private void Awake()
	{
		sprite = gameObject.GetComponent<SpriteRenderer>();
		number = Random.Range(0, 4);
		switch (number)
		{
			case 0:
				sprite.sprite = sprites[0];
				break;
			case 1:
				sprite.sprite = sprites[1];
				break;
			case 2:
				sprite.sprite = sprites[2];
				break;
			case 3:
				sprite.sprite = sprites[3];
				break;
			default:
				sprite.sprite = sprites[4];
				break;
		}
	}
	protected override void OnPickup(PlayerController player)
	{
		switch (number)
		{
			case 0:
				player.bonusAttack += 1f;
				break;
			case 1:
				player.bonusHealth += 1f;
				break;
			case 2:
				player.bonusJumpHeight += 2f;
				break;
			case 3:
				player.bonusMovementSpeed += 0.5f;
				break;
			default:
				player.bonusJumps++;
				break;
		}
	}
}
