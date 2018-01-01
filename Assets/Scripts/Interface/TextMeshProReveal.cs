using System.Collections;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextMeshProReveal : MonoBehaviour {
	IEnumerator Start() {
		TextMeshProUGUI tmPro = GetComponent<TextMeshProUGUI>();

		int totalCharacters = tmPro.textInfo.characterCount;
		int count = 0;

		while (count < totalCharacters) {
			tmPro.maxVisibleCharacters = count++;
			yield return new WaitForSeconds(0.05f);
		}
	}
}
