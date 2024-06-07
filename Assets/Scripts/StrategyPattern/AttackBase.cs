using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackBase : MonoBehaviour
{
    public abstract void Attack();

    //[SerializeField] Projectile _projectile = null;
    //protected Projectile Projectile => _projectile;

	[SerializeField] Transform _projectileSpawnLocation = null;
	protected Transform ProjectileSpawnLocation => _projectileSpawnLocation;

	[SerializeField] AudioClip _shootSound = null;
	protected AudioClip ShootSound => _shootSound;

	[SerializeField] private GameObject[] _projectiles = null;
	protected GameObject[] Projectiles => _projectiles;
}
