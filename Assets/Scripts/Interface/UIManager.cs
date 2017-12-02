using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {
	[SerializeField] private UIInteractable interactableUI;

	void Awake() {
		DontDestroyOnLoad(gameObject);
	}

	public void ShowInteraction(IInteractable obj) {
		interactableUI.Show(obj);
	}
}
