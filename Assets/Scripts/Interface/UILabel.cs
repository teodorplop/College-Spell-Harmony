using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class UILabel : MonoBehaviour {
	private TextMeshProUGUI tmpro;

	void Awake() {
		tmpro = GetComponent<TextMeshProUGUI>();
	}

	void Start() {
		tmpro.text = Strings.GetText(tmpro.text);
	}
}
