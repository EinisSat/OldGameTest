using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
	[Header ("Health")]
    [SerializeField] private float startingHealth;

	private UIManager uiManager;
	public float currentHealth { get; private set; }
	private Animator anim;
	public bool dead;
	private GameObject subject;
	private PlayerMovement playerMovement;
	[Header("I-Frames")]
	[SerializeField] private float iFramesDuration;
	[SerializeField] private int numberOfFlashes;
	private SpriteRenderer spriteRend;
	private Rigidbody2D body;

	[Header("Components")]
	[SerializeField] private Behaviour[] components;
	[SerializeField] private AudioClip deathFX;
	private bool invulnerable;

	private void Awake()
	{
		body = GetComponent<Rigidbody2D>();
		//startingHealth += playerController.bonusHealth;
		currentHealth = startingHealth;
		anim = GetComponent<Animator>();
		spriteRend = GetComponent<SpriteRenderer>();
		uiManager = FindFirstObjectByType<UIManager>();
	}

	public void TakeDamage(float _damage)
	{
		currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
		if (currentHealth > 0)
		{
			anim.SetTrigger("hurt");
			StartCoroutine(Invulnerability());
		}
		else
		{
			if (!dead)
			{
				AudioManager.instance.PlaySound(deathFX);
				foreach (Behaviour component in components)
				{
					component.enabled = false;
				}
				anim.SetBool("grounded", true);
				anim.SetTrigger("die");
				
				dead = true;
				if (this.GameObject() == GameObject.FindGameObjectWithTag("Player"))
				{
					body.velocity = Vector3.zero;
				}
			}
			
		}
	}
	private IEnumerator Invulnerability()
	{
		Physics2D.IgnoreLayerCollision(10, 11, true);
		//invulnerability duration
		for(int i = 0; i < numberOfFlashes; i++)
		{
			spriteRend.color = new Color(1, 0, 0, 0.5f);
			yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 3));
			spriteRend.color = Color.white;
			yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 3));
		}
		Physics2D.IgnoreLayerCollision(10, 11, false);
	}
	public void AddHealth(float _amount)
	{
		currentHealth = Mathf.Clamp(currentHealth + _amount, 0, startingHealth);
	}
	private void Deactivate()
	{
		gameObject.SetActive(false);
	}
	private void GameOver()
	{
		uiManager.GameOver();
	}
}
