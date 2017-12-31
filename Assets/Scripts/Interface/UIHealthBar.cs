using UnityEngine;
using TMPro;

public class UIHealthBar : MonoBehaviour {
	[SerializeField] private RectTransform healthBar;
	[SerializeField] private TextMeshProUGUI text;

	float healthBarWidth;

	void Awake() {
		healthBarWidth = GetComponent<RectTransform>().sizeDelta.x;
	}

	void Update() {
		if (Player.Instance == null) return;
		ShowHealth(Player.Instance.Health / Player.Instance.MaxHealth);
	}

	private void ShowHealth(float percentage) {
		float right = healthBarWidth * (percentage - 1.0f);

		healthBar.sizeDelta = new Vector2(right, healthBar.sizeDelta.y);
		text.text = (percentage * 100).ToString() + '%';
	}
}
