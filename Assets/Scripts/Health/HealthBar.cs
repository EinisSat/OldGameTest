using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	private Health playerHealth;
	[SerializeField] private Image totalhealthBar;
	[SerializeField] private Image currenthealthBar;
	private GameObject player;
	private void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		playerHealth = player.GetComponent<Health>();
		totalhealthBar.fillAmount = playerHealth.currentHealth / 10;
	}

	private void Update()
	{
		currenthealthBar.fillAmount = playerHealth.currentHealth / 10;
	}

}
