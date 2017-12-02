using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable {
	bool enableInteraction { get; set; }
	string interactionString { get; }
	void OnInteract();
}
