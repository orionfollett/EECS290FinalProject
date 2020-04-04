using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour {
	[SerializeField] private Text scoreLabel;
	[SerializeField] private SettingsPopup settingsPopup;
	[SerializeField] private GameObject gameOver;

	private int _score;

	void Awake() {
		Messenger.AddListener(GameEvent.ENEMY_HIT, OnEnemyHit);
	}
	void OnDestroy() {
		Messenger.RemoveListener(GameEvent.ENEMY_HIT, OnEnemyHit);
	}

	void Start() {
		gameOver.SetActive(false);
		_score = 0;
		scoreLabel.text = _score.ToString();

		settingsPopup.Close();
	}

	private void OnEnemyHit() {
		_score += 1;
		scoreLabel.text = _score.ToString();
		if (_score == 10)
		{
			gameOver.SetActive(true);
		}
	}

	public void OnOpenSettings() {
		settingsPopup.Open();
	}

	public void OnPointerDown() {
		Debug.Log("pointer down");
	}

	public void OnExitButtonClick() {
		Application.Quit();
	}
}
