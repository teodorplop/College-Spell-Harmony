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

		CastSpells();
	}

	void CastSpells() {
		Player player = Player.Instance;
		Vector3 dir = player.GetComponentInChildren<Camera>().transform.forward;

		if (Input.GetKeyUp(KeyCode.Alpha1))
			spellLauncher.Fireball(player.transform, player, dir);
		else if (Input.GetKeyUp(KeyCode.Alpha2))
			spellLauncher.Shield(player.transform, player);
		else if (Input.GetKeyUp(KeyCode.Alpha3))
			spellLauncher.Frostbolt(player.transform, player, dir);
		else if (Input.GetKeyUp(KeyCode.Alpha4))
			spellLauncher.LightingBolt(player.transform, player, dir);
	}

	GameObject GetObjectInFront() {
		RaycastHit hit;
		return Physics.Raycast(player.transform.position, player.transform.forward, out hit, 2) ? hit.collider.gameObject : null;
	}
}
