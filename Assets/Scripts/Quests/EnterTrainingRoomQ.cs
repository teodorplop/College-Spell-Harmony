using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterTrainingRoomQ : MonoBehaviour {
	[SerializeField] private GameObject trainingRoomPrefab;
	[SerializeField] private GameObject activeTrainingRoom;

	void Update() {
		float dist = Vector3.Distance(transform.position, Player.Instance.transform.position);
		if (dist <= 5) {// ugly af... :O indeed
			QuestManager.Instance.EnterTrainingRoom();

			if (Input.GetKeyUp(KeyCode.T))
				ResetTrainingRoom();
		}
	}

	private void ResetTrainingRoom() {
		Destroy(activeTrainingRoom);

		GameObject go = Instantiate(trainingRoomPrefab, transform.parent);
		go.transform.localPosition = Vector3.zero;
		go.transform.localScale = Vector3.one;
		go.transform.localRotation = Quaternion.identity;

		activeTrainingRoom = go;
	}
}
