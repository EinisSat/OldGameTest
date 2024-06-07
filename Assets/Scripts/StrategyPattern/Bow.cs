using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : AttackBase
{
	public override void Attack()
	{
		Invoke("Shoot", 0.54f); // Activate hitbox after 0.2 seconds.
		
	}
	void Shoot()
	{
		Projectiles[FindProjectile()].transform.position = ProjectileSpawnLocation.position;
		Projectiles[FindProjectile()].GetComponent<Projectile>().SetDirection(Mathf.Sign(ProjectileSpawnLocation.localScale.x));
		AudioManager.instance.PlaySound(ShootSound);
	}
	private int FindProjectile()
	{
		for (int i = 0; i < Projectiles.Length; i++)
		{
			if (!Projectiles[i].activeInHierarchy)
				return i;
		}
		return 0;
	}
}
