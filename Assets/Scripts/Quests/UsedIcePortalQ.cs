using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsedIcePortalQ : MonoBehaviour {
	void Awake() {
		GetComponent<Portal>().OnInteractEvent += UsedIcePortalQ_OnInteractEvent;
	}
	void OnDestroy() {
		GetComponent<Portal>().OnInteractEvent -= UsedIcePortalQ_OnInteractEvent;
	}

	private void UsedIcePortalQ_OnInteractEvent() {
		QuestManager.Instance.IcePortal();
	}
}
