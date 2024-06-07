using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private Health health;
	[SerializeField] private PlayerMovement movement;
	[SerializeField] public float bonusHealth = 0;
	[SerializeField] public float bonusAttack = 0;
	[SerializeField] public float bonusMovementSpeed = 0;
	[SerializeField] public float bonusJumpHeight = 0;
	[SerializeField] public float bonusJumps = 0;

	private void Awake()
	{
		health = GetComponent<Health>();
		movement = GetComponent<PlayerMovement>();
	}
}
