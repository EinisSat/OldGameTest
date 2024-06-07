using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()
    {
		SceneManager.LoadScene(0);
	}
    public void Quit()
    {
        Application.Quit();
    }
	public void Play()
	{
		SceneManager.LoadScene(1);
	}
}
