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
		canvasGroup.alpha = GameState.Dead ? 1 : 0;
		canvasGroup.blocksRaycasts = GameState.Dead;
	}
}