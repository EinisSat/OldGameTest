using Unity.Burst.CompilerServices;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private CapsuleCollider2D hitbox;
    [SerializeField] private Transform firepoint;
	[SerializeField] private GameObject[] projectiles;
	[SerializeField] private AudioClip attackSound;
    private Animator anim;
    private PlayerMovement playerMovement;
	private float cooldownTimer = Mathf.Infinity;
	private float horizontalInput;

	[SerializeField] private AttackBase weapon;

	private void Awake()
	{
		hitbox.gameObject.SetActive(false);
		anim = GetComponent<Animator>();
		playerMovement = GetComponent<PlayerMovement>();
	}

	private void Update()
	{
		horizontalInput = Input.GetAxis("Horizontal");

		//Flip player when moving sideways
		if (horizontalInput > 0.01f)
			firepoint.localScale = new Vector3(2, 2, 2);
		else if (horizontalInput < -0.01f)
			firepoint.localScale = new Vector3(-2, 2, 2);

		if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerMovement.canAttack())
		{
			UseWeapon();
		}

		cooldownTimer += Time.deltaTime;
	}

	private void Attack()
	{
		anim.SetTrigger("attack");
		Invoke("ActivateHitbox", 0.09f); // Activate hitbox after 0.2 seconds.
		Invoke("DeactivateHitbox", 0.17f); // Deactivate hitbox after 0.4 seconds.
		cooldownTimer = 0;
	}
	void ActivateHitbox()
	{
		hitbox.gameObject.SetActive(true);
		AudioManager.instance.PlaySound(attackSound);
	}

	void DeactivateHitbox()
	{
		hitbox.gameObject.SetActive(false);
	}
	private void UseWeapon()
	{
		anim.SetTrigger("attack");
		cooldownTimer = 0;
		weapon.Attack();
	}
	/*private void Shoot()
	{
		anim.SetTrigger("attack");
		cooldownTimer = 0;


		projectiles[FindProjectile()].transform.position = firepoint.position;
		projectiles[FindProjectile()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
	}
	private int FindProjectile()
	{
		for (int i = 0; i < projectiles.Length; i++)
		{
			if (!projectiles[i].activeInHierarchy)
				return i;
		}
		return 0;
	}*/
}
