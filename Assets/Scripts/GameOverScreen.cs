using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverScreen : MonoBehaviour
{
	[SerializeField] private Button tryAgainButton;
	private CanvasGroup canvasGroup;

	void RestartGame()
	{
		print("Restarting level...");
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	void Awake()
	{
		canvasGroup = GetComponent<CanvasGroup>();
	}

	void Start()
	{
		tryAgainButton.onClick.AddListener(RestartGame);
	}

	void Update()
	{
		if (GameState.Dead) canvasGroup.alpha = 1;
		else canvasGroup.alpha = 0;
	}
}