using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {
	[SerializeField] private UIInteractable interactableUI;
	[SerializeField] private GameObject defeatedScreen;
	[SerializeField] private GameObject overlay;

	void Awake() {
		DontDestroyOnLoad(gameObject);
	}

	public void ShowInteraction(IInteractable obj) {
		interactableUI.Show(obj);
	}

	public void Defeated() {
		overlay.SetActive(true);
		defeatedScreen.SetActive(true);
	}
	public void Revive() {
		overlay.SetActive(false);
		defeatedScreen.SetActive(false);

		SceneLoader.Load("UPB");
	}
}
