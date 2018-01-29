using System;
using UnityEngine;

public class Portal : MonoBehaviour, IInteractable {
	[SerializeField] private string sceneLoaded;

	public bool enableInteraction { get; set; }

	public delegate void onInteract();
	public event onInteract OnInteractEvent;

	public string interactionString {
		get { return "STR_INTERACTABLE_PORTAL"; }
	}

	public void OnInteract() {
		if (sceneLoaded == "") return;
		SceneLoader.Load(sceneLoaded);
		if (OnInteractEvent != null) OnInteractEvent();
	}
}
