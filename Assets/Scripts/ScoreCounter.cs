using System;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
	[SerializeField] private float animationDuration;
	[SerializeField] private float animationDisplacement;

	private int lastScore;
	private float animationTime;
	private bool animationRunning;

	private TextMeshProUGUI textMesh;

	void Awake()
	{
		textMesh = GetComponent<TextMeshProUGUI>();
		lastScore = 0;
	}

	void Update()
	{
		if (animationTime >= animationDuration)
		{
			animationTime = 0;
			animationRunning = false;
		}

		if (animationRunning)
		{
			transform.rotation = Quaternion.Slerp(Quaternion.Euler(0, 0, -animationDisplacement), Quaternion.Euler(0, 0, 0), animationTime / animationDuration);
			animationTime += Time.deltaTime;
		}

		if (GameState.Score != lastScore)
		{
			animationRunning = true;
		}

		textMesh.text = GameState.Score.ToString();
		lastScore = GameState.Score;
	}
}