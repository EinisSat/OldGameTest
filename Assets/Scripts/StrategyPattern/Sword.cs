using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : AttackBase
{
	public override void Attack()
	{
		Invoke("ActivateHitbox", 0.09f); // Activate hitbox after 0.2 seconds.
		Invoke("DeactivateHitbox", 0.17f); // Deactivate hitbox after 0.4 seconds.
	}
	void ActivateHitbox()
	{
		Projectiles[0].gameObject.SetActive(true);
		AudioManager.instance.PlaySound(ShootSound);
	}

	void DeactivateHitbox()
	{
		Projectiles[0].gameObject.SetActive(false);
	}
}
