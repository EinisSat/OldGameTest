using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
	[SerializeField] private GameObject warrior;
	[SerializeField] private GameObject ranger;
	[SerializeField] private GameObject wizard;
	public void Warrior()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene(3);
	}
	public void Ranger()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene(2);
	}
	public void Wizard()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene(4);
	}
}
