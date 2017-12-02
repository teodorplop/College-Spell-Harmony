using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameManager {
	IEnumerator Default_EnterState() {
		yield break;
	}

	void Default_Update() {
		GameObject inFront = GetObjectInFront();

		if (inFront != null) {
			IInteractable interactable = inFront.GetComponent<IInteractable>();
			uiManager.ShowInteraction(interactable);

			if (interactable != null && Input.GetKeyUp(KeyCode.F))
				interactable.OnInteract();
		} else
			uiManager.ShowInteraction(null);
	}

	GameObject GetObjectInFront() {
		RaycastHit hit;
		return Physics.Raycast(player.transform.position, player.transform.forward, out hit, 2) ? hit.collider.gameObject : null;
	}
}
