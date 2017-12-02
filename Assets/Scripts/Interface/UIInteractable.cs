using UnityEngine;
using TMPro;

public class UIInteractable : MonoBehaviour {
	[SerializeField] private TextMeshProUGUI label;

	public void Show(IInteractable obj) {
		if (obj == null)
			gameObject.SetActive(false);
		else {
			label.text = Strings.GetText(obj.interactionString);
			gameObject.SetActive(true);
		}
	}
}
